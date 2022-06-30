using MVC_study;
using MVC_study.DomainEvents;
using MVC_study.Services;

namespace Lesson.DI.DomainEvents
{
    public  class ProductAddedMailSender : BackgroundService
    {
        private readonly IMailService _mail;
        private readonly ILogger<ProductAddedMailSender> _logger;

        public ProductAddedMailSender(IMailService mail, ILogger<ProductAddedMailSender> logger)
        {
            _mail = mail;
            _logger = logger;
            DomainEventsManager.Register<ProductAdded>(e => _ = SendMailNotification(e));
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            return Task.CompletedTask;
        }

        private async Task SendMailNotification(ProductAdded e)
        {
            try
            {
                List<string> to = new();
                to.Add("daniil_sviridov@mail.ru");

                _ = _mail.SendAsync(new MailData(to, "Добавлен новый товар!", $" id: {e.Product.Id} name: {e.Product.Name}"), new CancellationToken());

                _logger.LogInformation("Сообщение о добавлении товара");
            }
            catch (Exception ex)
            {
                _logger.LogError("Ошибка отправки");
            };
        }
    }
}
