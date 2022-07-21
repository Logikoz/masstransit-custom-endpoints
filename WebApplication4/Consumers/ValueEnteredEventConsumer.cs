using MassTransit;
using Messages;

namespace WebApplication4.Consumers
{
	internal class ValueEnteredEventConsumer : IConsumer<ValueEntered>
	{
		private readonly ILogger<ValueEnteredEventConsumer> _logger;

		public ValueEnteredEventConsumer(ILogger<ValueEnteredEventConsumer> logger)
		{
			_logger = logger;
		}

		public async Task Consume(ConsumeContext<ValueEntered> context)
		{
			_logger.LogInformation(context.Message.Value);
		}
	}
}