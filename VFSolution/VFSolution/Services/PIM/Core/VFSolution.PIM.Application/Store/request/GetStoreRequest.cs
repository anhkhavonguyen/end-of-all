using System;
using System.Collections.Generic;
using System.Text;
using VFSolution.PIM.Application.Extentions;

namespace VFSolution.PIM.Application.Store.request
{
    public class GetStoreRequest : CommonRequest
    {
        public Guid? CustomerId { get; set; }
    }
}
