namespace HrSolution.Entities

{
    public class UserRole
    {
        public virtual User User { get; set; }
        public int UserId { get; set; }
        public Role Role { get; set; }
        public int RoleId { get; set; }
    }
}