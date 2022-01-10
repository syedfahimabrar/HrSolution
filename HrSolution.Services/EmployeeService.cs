using HrSolution.Entities;
using HrSolution.Repositories;

namespace HrSolution.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly INotificationUnitofWork _unitofWork;

        public EmployeeService(INotificationUnitofWork unitofWork)
        {
            _unitofWork = unitofWork;
        }

        public void UpdateProfile(Employee employee,User currentUser)
        {
            if (employee.UserId != currentUser.Id)
                throw new Exception("Only user himself can update employee profile");

            _unitofWork.EmployeeRepository.Edit(employee);

            var manager = _unitofWork.EmployeeRepository
                .Get(u => u.Superintendent.Any(x => x.UserId == currentUser.Id)).FirstOrDefault();
            var notification = new Notification()
            {
                EmployeeId = manager.Id,
                NotificationType = NotificationType.profile_update,
                Route = $"/profile/{currentUser.UserName}",
                Message = $"profile of {currentUser.UserName} has been updated"
            };
            _unitofWork.NotificationRepository.Add(notification);

            _unitofWork.NotificationQueueRepository.Add(new()
            {
                Notification = notification,
                Status = QueueStatus.NEW
            });

            _unitofWork.Save();

        }

    }
}