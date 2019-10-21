using KVSolution.PIM.Application.Extentions;

namespace KVSolution.PIM.Application.Blogs.Request
{
    public class BlogRequest
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public string Link { get; set; }
        public string CategoryId { get; set; }
    }
}
