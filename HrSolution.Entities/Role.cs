using System.Collections.Generic;
using HrSolution.Data;

namespace HrSolution.Entities
{
    public class Role:IEntity<int>
    {
        public Role()
        {
            this.UserRoles = new List<UserRole>();
        }
        public string Name { get; set; }
        public ICollection<UserRole> UserRoles { get; set; }
        public int Id { get; set; }
    }
}