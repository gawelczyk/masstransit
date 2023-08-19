using MassTransit;

namespace sdk1
{
    public class PingConsumer : IConsumer<Ping>
    {
        private readonly ILogger<PingConsumer> logger;

        public PingConsumer(ILogger<PingConsumer> logger)
        {
            this.logger = logger;
        }

        public Task Consume(ConsumeContext<Ping> context)
        {
            var button = context.Message.Button;
            logger.LogInformation("Button pressed {Button}", button);
            return Task.CompletedTask;
        }
    }
}
