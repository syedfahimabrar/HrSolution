using HrSolution.Entities;
using HrSolution.Services;

namespace HrSolution.NotificationWorker
{
	public class Worker : BackgroundService
	{
        private readonly ILogger<Worker> _logger;
        private readonly INotificationService _notificationService;

        public Worker(ILogger<Worker> logger, INotificationService notificationService)
        {
            _logger = logger;
            _notificationService = notificationService;
        }

        private async Task SendEmailAsync(NotificationQueue notificationQueue)
        {
            // send email via email service
        }

        private async Task SendSMSAsync(NotificationQueue notificationQueue)
        {
            // send sms via sms service
        }

        private async Task SendPushNotificationAsync(NotificationQueue notificationQueue)
		{
            // send push notification via signalR
		}

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                var queues = _notificationService.NotificationToProcess();
                _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
                foreach (var queue in queues)
                {
                    switch(queue.Notification.Employee.EnabledNotification)
					{
                        case NotificationMedium.email:
                            SendEmailAsync(queue); // async not called as we dont want to inturrept loop for result and we dont need the result
                            break;
                        case NotificationMedium.sms:
                            SendSMSAsync(queue);
                            break;
                        case NotificationMedium.web:
                            SendPushNotificationAsync(queue);
                            break;
					}
                }
                await Task.Delay(1000, stoppingToken);
            }
        }
    }
}