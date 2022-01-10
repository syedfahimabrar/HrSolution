using System;
using System.Collections.Generic;
using HrSolution.Entities;

namespace HrSolution.Services
{
    public interface INotificationService
    {
        ICollection<Notification> GetAllNotification(int userid);
        Notification Get(int id);
        void Seen(int id);
        void Dispose();
        IList<NotificationQueue> NotificationToProcess();
        void UpdateNotificationQueue(NotificationQueue queue);
        void SendNotification(Action<NotificationQueue> notify,NotificationQueue notificationQueue);
    }
}