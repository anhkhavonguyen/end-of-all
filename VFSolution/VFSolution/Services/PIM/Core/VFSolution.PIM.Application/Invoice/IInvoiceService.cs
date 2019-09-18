using System.Threading.Tasks;
using VFSolution.PIM.Application.Extentions;
using VFSolution.PIM.Application.Invoice.Request;
using VFSolution.PIM.Application.Invoice.Request.Create;
using VFSolution.PIM.Application.Invoice.Request.Update;

namespace VFSolution.PIM.Application.Invoice
{
    public interface IInvoiceService
    {
        Task<bool> CreateAsync(CreateInvoiceRequest request);

        Task<string> UpdateAsync(UpdateInvoiceRequest request);

        PagedResult<InvoiceModel> Get(CommonRequest request);
    }
}
