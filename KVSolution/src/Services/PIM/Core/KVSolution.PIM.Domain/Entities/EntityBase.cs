using System;

namespace KVSolution.PIM.Domain.Entities
{
    /// <summary>
    /// Domain layer just implement business rule for that domain, can apply that business rule for many application layer
    /// </summary>
    public abstract class EntityBase
    {
        public Guid Id { get; set; }
        public Guid CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public Guid? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public bool IsDelete { get; set; }
    }
}
