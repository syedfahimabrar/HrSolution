using HrSolution.Data;
using System;

namespace HrSolution.Entities
{
    public class LeaveApplication: IEntity<int>
    {
        public int UserId { get; set; }
        public int Employeeid { get; set; }
        public virtual Employee Employee { get; set; }
        public virtual User User { get; set; }
        public DateTime From { get; set; }
        public DateTime To { get; set; }
        public LeaveStatus CurrentStatus { get; set; }
        public int Id { get; set; }
    }

    public enum LeaveStatus
    {
        queued,
        approved,
        rejected,
        cancelled
    }
}