namespace KVSolution.PIM.Domain.Entities
{
    public class Blog : EntityBase
    {
        public Blog()
        {

        }
        public string Title { get; set; }
        public string Text { get; set; }
        public string Link { get; set; }
        public string CategoryId { get; set; }
        public virtual Category Category { get; set; }
    }
}
