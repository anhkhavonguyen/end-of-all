using System.Collections.Generic;
using VFSolution.PIM.Application.Extentions;

namespace VFSolution.PIM.Application.PurchaseOrder.Request.Create
{
    public class CreatePORequest : CommonRequest
    {
        public POModel POModel { get; set; }
        public List<POItemModel> POItems { get; set; }
    }
}
