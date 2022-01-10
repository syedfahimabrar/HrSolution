using HrSolution.Data;
using HrSolution.Entities;

namespace HrSolution.Repositories
{
    public class NotificationRepository:Repository<Notification,int,FrameWorkContext>, INotificationRepository
    {
        public NotificationRepository(FrameWorkContext context) : base(context)
        {
        }
    }
}