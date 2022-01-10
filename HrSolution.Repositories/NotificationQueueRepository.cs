

using HrSolution.Data;
using HrSolution.Entities;

namespace HrSolution.Repositories
{
    public class NotificationQueueRepository:Repository<NotificationQueue,int,FrameWorkContext>, INotificationQueueRepository
    {
        public NotificationQueueRepository(FrameWorkContext context) : base(context)
        {
        }
    }
}