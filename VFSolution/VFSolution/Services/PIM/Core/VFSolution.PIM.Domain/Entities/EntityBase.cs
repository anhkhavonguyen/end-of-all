using System;

namespace VFSolution.PIM.Domain.Entities
{
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
