using System;

namespace KVSolution.PIM.Domain.Entities
{
    public class UserRole
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid UserId { get; set; }
        public virtual User User { get; set; }
    }
}
