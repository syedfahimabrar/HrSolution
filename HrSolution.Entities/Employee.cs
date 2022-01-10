
using HrSolution.Data;

namespace HrSolution.Entities
{
    public class Employee:IEntity<int>
    {
        public virtual User User { get; set; }
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public int ManagerId { get; set; }
        public virtual Employee Manager { get; set; }
        public NotificationMedium EnabledNotification { get; set; }

        public IList<Employee> Superintendent { get; set; }

        public int Id { get; set; }
    }

    public enum NotificationMedium
    {
        email,
        sms,
        web
    }
}