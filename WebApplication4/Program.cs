using MassTransit;
using WebApplication4.Consumers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

var services = builder.Services;

services.AddMassTransit(x =>
{
	x.AddConsumer<ValueEnteredEventConsumer>();

	x.SetEndpointNameFormatter(new EndpointNameFormatter("lk-a1"));

	x.UsingRabbitMq((context, cfg) =>
	{
		cfg.Host("localhost", 5672, "/", x =>
		{
			x.Password("guest");
			x.Username("guest");
		});

		cfg.ConfigureEndpoints(context);
	});
});

var app = builder.Build();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

internal class EndpointNameFormatter : DefaultEndpointNameFormatter
{
	private const char SEPARATOR = ':';

	public new static IEndpointNameFormatter Instance { get; } = new EndpointNameFormatter();

	protected EndpointNameFormatter()
	{
	}

	public EndpointNameFormatter(string prefix)
		: base($"{prefix}{SEPARATOR}", false)
	{
	}
}