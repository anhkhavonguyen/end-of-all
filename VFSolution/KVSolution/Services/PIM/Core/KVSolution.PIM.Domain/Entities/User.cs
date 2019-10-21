using System;
using System.Collections.Generic;

namespace KVSolution.PIM.Domain.Entities
{
    public class User : EntityBase
    {
        public User()
        {
            UserRoles = new HashSet<UserRole>();
        }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public DateTime DoB { get; set; }
        public string Email { get; set; }
        public Guid RoleId { get; set; }
        public virtual ICollection<UserRole> UserRoles { get; set; }
    }
}
