using System.Collections.Generic;
using HrSolution.Entities;

namespace HrSolution.Services
{
    public interface ILeaveService
    {
        ICollection<LeaveApplication> GetAllLeaveApplication();
        void Dispose();
        void GetLeave(LeaveApplication leaveApplication);
        public void ChangeLeaveStatus(int id, LeaveStatus status, User currentUser);
    }
}