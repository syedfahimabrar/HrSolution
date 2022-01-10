
using HrSolution.Entities;

namespace HrSolution.Services
{
    public interface IEmployeeService
    {
        void UpdateProfile(Employee employee, User currentUser);
    }
}