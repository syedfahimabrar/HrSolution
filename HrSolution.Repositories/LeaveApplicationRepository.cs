using HrSolution.Data;
using HrSolution.Entities;

namespace HrSolution.Repositories
{
    public class LeaveApplicationRepository: Repository<LeaveApplication, int, FrameWorkContext>, ILeaveApplicationRepository
    {
        public LeaveApplicationRepository(FrameWorkContext context) : base(context)
        {
        }
    }
}