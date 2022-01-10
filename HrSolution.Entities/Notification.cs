using HrSolution.Data;
using System;

namespace HrSolution.Entities
{
    public class Notification:IEntity<int>
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public virtual Employee Employee { get; set; }
        public string Message { get; set; }
        public NotificationType NotificationType { get; set; }
        public string Route { get; set; }
        public bool IsSeen { get; set; }
    }

    public enum NotificationType
    {
        profile_update,
        request_leave,
        cancelled_leave,
        rejected_leave,
        approved_leave
    }
}