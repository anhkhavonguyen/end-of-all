using System.Threading.Tasks;
using VFSolution.PIM.Application.Extentions;
using VFSolution.PIM.Application.PurchaseOrder.Request;
using VFSolution.PIM.Application.PurchaseOrder.Request.Create;
using VFSolution.PIM.Application.PurchaseOrder.Request.Delete;
using VFSolution.PIM.Application.PurchaseOrder.Request.Update;

namespace VFSolution.PIM.Application.PurchaseOrder
{
    public interface IPurchaseOrderService
    {
        Task<bool> CreateAsync(CreatePORequest request);

        Task<string> UpdateAsync(UpdatePORequest request);

        PagedResult<POModel> Get(CommonRequest request);

        Task<string> DeleteAsync(DeletePORequest request);
    }
}
