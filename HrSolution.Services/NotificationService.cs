using System;
using System.Collections.Generic;
using HrSolution.Entities;
using HrSolution.Repositories;

namespace HrSolution.Services
{
    public class NotificationService:IDisposable,  INotificationService
    {
        private readonly INotificationUnitofWork _unitofWork;

        public NotificationService(INotificationUnitofWork unitofWork)
        {
            _unitofWork = unitofWork;
        }

        public ICollection<Notification> GetAllNotification(int employeeId)
        {
            return _unitofWork.NotificationRepository.Get(x => x.EmployeeId == employeeId);
        }

        public Notification Get(int id)
        {
            return _unitofWork.NotificationRepository.GetById(id);
        }

        public void Seen(int id)
        {
            var notification = _unitofWork.NotificationRepository.GetById(id);
            notification.IsSeen = true;
            _unitofWork.NotificationRepository.Edit(notification);
            _unitofWork.Save();
        }

        public void Dispose()
        {
            this._unitofWork.Dispose();
        }

        public IList<NotificationQueue> NotificationToProcess()
        {
            return _unitofWork.NotificationQueueRepository.Get(x => x.Status == QueueStatus.NEW);
        }

        public void UpdateNotificationQueue(NotificationQueue queue)
        {
            _unitofWork.NotificationQueueRepository.Edit(queue);
            _unitofWork.Save();
        }
        public void SendNotification(Action<NotificationQueue> notify,NotificationQueue notificationQueue)
        {
            notify(notificationQueue);
        }
    }
}