using MassTransit;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

var services = builder.Services;

services.AddMassTransit(x =>
{
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