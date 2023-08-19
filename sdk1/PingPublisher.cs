using MassTransit;

namespace sdk1
{
    public class PingPublisher : BackgroundService
    {
        private readonly ILogger<PingPublisher> logger;
        private readonly IBus bus;

        public PingPublisher(ILogger<PingPublisher> logger, IBus bus)
        {
            this.logger = logger;
            this.bus = bus;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                await Task.Yield();
                var keyPressed = Console.ReadKey(true);
                if (keyPressed.Key != ConsoleKey.Escape)
                {
                    //logger.LogInformation("Pressed {Button}", keyPressed.Key.ToString());
                    await bus.Publish(new Ping(keyPressed.Key.ToString()));
                }
                else
                {
                    Environment.Exit(1);
                }
                await Task.Delay(200);
            }
        }
    }
}
