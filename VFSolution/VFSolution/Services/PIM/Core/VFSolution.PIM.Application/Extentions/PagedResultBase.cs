using System;
using System.Collections.Generic;

namespace VFSolution.PIM.Application.Extentions
{
    public abstract class PagedResultBase
    {
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public int TotalItem { get; set; }
        public bool IsSuccess { get; set; }

        public int FirstRowOnPage
        {
            get { return (PageIndex) * PageSize + 1; }
        }

        public int LastRowOnPage
        {
            get { return Math.Min(PageIndex * PageSize, TotalItem); }
        }
    }

    public class PagedResult<T> : PagedResultBase where T : class
    {
        public List<T> Results { get; set; }

        public PagedResult()
        {
            Results = new List<T>();
        }
    }
}
