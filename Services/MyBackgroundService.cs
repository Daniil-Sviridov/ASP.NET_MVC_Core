using System.Diagnostics;

namespace MVC_study.Services
{
    public class MyBackgroundService : BackgroundService
    {
        private readonly ILogger<MyBackgroundService> _logger;
        private readonly IServiceProvider _servicelocator;

        public MyBackgroundService(ILogger<MyBackgroundService> logger, IServiceProvider servicelocator)
        {
            _logger = logger;
            _servicelocator = servicelocator;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            using var timer = new PeriodicTimer(TimeSpan.FromMinutes(10));
            Stopwatch sw = Stopwatch.StartNew();
            while (await timer.WaitForNextTickAsync(stoppingToken))
            {

                var p = _servicelocator.GetRequiredService<IMailService>();
                if (p != null)
                {
                    await p.SendAsync(new MailData(new List<string>() { "daniil_sviridov@mail.ru" }, $" " +
                        $"Полёт нормальный - {DateTimeOffset.Now}"), stoppingToken);
                }

                _logger.LogInformation("Сервер работает уже {WorkTime}", sw.Elapsed);
            }
        }
    }
}
