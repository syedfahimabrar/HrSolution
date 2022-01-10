using System;
using HrSolution.Data;
using HrSolution.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DevSkillSystem.web.All
{
    public class NotificationUnitofWork:UnitOfWork, INotificationUnitofWork
    {
        public NotificationUnitofWork(DbContext dbContext, ILeaveApplicationRepository leaveApplicationRepository,
            INotificationRepository notificationRepository, INotificationQueueRepository notificationQueueRepository,
            IEmployeeRepository employeeRepository) : base(dbContext)
        {
            LeaveApplicationRepository = leaveApplicationRepository ??
                                         throw new ArgumentNullException(nameof(leaveApplicationRepository));
            NotificationRepository =
                notificationRepository ?? throw new ArgumentNullException(nameof(notificationRepository));
            NotificationQueueRepository = notificationQueueRepository ??
                                          throw new ArgumentNullException(nameof(notificationQueueRepository));
            EmployeeRepository = employeeRepository ?? throw new ArgumentNullException(nameof(employeeRepository));
        }

        public ILeaveApplicationRepository LeaveApplicationRepository { get; private set; }
        public INotificationRepository NotificationRepository { get; private set; }
        public INotificationQueueRepository NotificationQueueRepository { get; private set; }
        public IEmployeeRepository EmployeeRepository { get; private set; }
    }
}