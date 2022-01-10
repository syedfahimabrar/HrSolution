
using HrSolution.Repositories;

namespace HrSolution.Repositories
{
    public interface INotificationUnitofWork
    {
        ILeaveApplicationRepository LeaveApplicationRepository { get; }
        INotificationRepository NotificationRepository { get; }
        INotificationQueueRepository NotificationQueueRepository { get; }
        IEmployeeRepository EmployeeRepository { get; }
        void Dispose();
        void Save();
    }
}