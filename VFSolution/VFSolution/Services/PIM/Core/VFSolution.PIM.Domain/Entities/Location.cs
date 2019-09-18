namespace VFSolution.PIM.Domain.Entities
{
    public class Location: EntityBase
    {
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }
        public string TaxCode { get; set; }
        public string Address { get; set; }
    }
}
