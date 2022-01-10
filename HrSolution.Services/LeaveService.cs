using HrSolution.Entities;
using HrSolution.Repositories;
using System;
using System.Collections.Generic;

namespace HrSolution.Services
{
    public class LeaveService:IDisposable, ILeaveService
    {
        private readonly INotificationUnitofWork _unitofWork;

        public LeaveService(INotificationUnitofWork unitofWork)
        {
            _unitofWork = unitofWork;
        }

        public ICollection<LeaveApplication> GetAllLeaveApplication()
        {
            return new List<LeaveApplication>();
        }

        public void Dispose()
        {
            _unitofWork.Dispose();
        }

        public void GetLeave(LeaveApplication leaveApplication)
        {
            if (leaveApplication == null)
                throw new ArgumentNullException("leave application cant be null");

            if(leaveApplication?.UserId == null)
                throw new ArgumentException("leave should be taken for a user");
			
            var manager = _unitofWork.EmployeeRepository.Get(u => u.Superintendent.Any(x => x.UserId == leaveApplication.UserId)).FirstOrDefault();
            

            _unitofWork.LeaveApplicationRepository.Add(leaveApplication);

            var notification = this.LeaveStatusToNotification(leaveApplication);
            notification.EmployeeId = manager?.Id ?? notification.EmployeeId;
            _unitofWork.NotificationRepository.Add(notification);

            _unitofWork.NotificationQueueRepository.Add(new (){
                Notification = notification,
                Status = QueueStatus.NEW
            });

            _unitofWork.Save();
        }

        public void ChangeLeaveStatus(int id,LeaveStatus status,User currentUser)
        {
            var leave = _unitofWork.LeaveApplicationRepository.GetById(id);

            if (currentUser.Id == leave.UserId)
                throw new Exception("User cant change his own leave status");

            leave.CurrentStatus = status;
            _unitofWork.LeaveApplicationRepository.Edit(leave);

            var notification = this.LeaveStatusToNotification(leave);
            notification.EmployeeId = _unitofWork.EmployeeRepository.Get(e => e.UserId == leave.UserId).FirstOrDefault().Id;
            _unitofWork.NotificationRepository.Add(notification);

            _unitofWork.NotificationQueueRepository.Add(new()
            {
                Notification = notification
            });

            
            _unitofWork.Save();
        }

        private Notification LeaveStatusToNotification(LeaveApplication leave) => leave.CurrentStatus switch
        {
            LeaveStatus.queued => new()
            {
                Message = "New leave has been created",
                NotificationType = NotificationType.request_leave,
                Route = $"/leave/{leave.Id}"
            },
            LeaveStatus.cancelled => new()
            {
                Message = "Employee has been cancelled leave",
                NotificationType = NotificationType.cancelled_leave,
                Route = $"/leave/{leave.Id}"
            },
            LeaveStatus.rejected => new()
            {
                Message = "Your leave has been rejected",
                NotificationType = NotificationType.rejected_leave,
                Route = $"/leave/{leave.Id}"
            },
            LeaveStatus.approved => new()
            {
                Message = "Your leave has been approved",
                NotificationType = NotificationType.approved_leave,
                Route = $"/leave/{leave.Id}"
            }
        };
    }
}