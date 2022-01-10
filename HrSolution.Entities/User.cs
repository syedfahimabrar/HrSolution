using System.Collections.Generic;
using HrSolution.Data;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace HrSolution.Entities
{
    public class User:IEntity<int>
    {
        public User()
        {
            this.UserRoles = new List<UserRole>();
        }
        public string Password { get; set; }
        public string UserName { get; set; }

        public virtual Employee Employee { get; set; }
        public ICollection<UserRole> UserRoles { get; set; }
        public int Id { get; set; }
    }
}