using System;
using System.Collections.Generic;
using System.Text;

namespace VFSolution.PIM.Domain.Entities
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
    }
}
