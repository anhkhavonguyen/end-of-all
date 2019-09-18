using System;

namespace VFSolution.PIM.Application.Extentions
{
    public abstract class BaseRequest
    {
        public string UserId { get; set; } = string.Empty;
        public string SearchText { get; set; } = string.Empty;
    }

    public class CommonRequest: BaseRequest
    {
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public DateTime? DateFilter { get; set; }
    }
}
