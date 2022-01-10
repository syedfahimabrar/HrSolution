using HrSolution.Data;
using HrSolution.Entities;

namespace HrSolution.Repositories
{
    public class EmployeeRepository : Repository<Employee, int, FrameWorkContext>, IEmployeeRepository
    {
        public EmployeeRepository(FrameWorkContext context) : base(context)
        {
        }
    }
}