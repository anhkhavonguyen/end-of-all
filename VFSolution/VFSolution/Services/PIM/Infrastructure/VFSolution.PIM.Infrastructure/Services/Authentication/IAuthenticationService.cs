using System.Threading.Tasks;
using VFSolution.Common.Config;

namespace VFSolution.PIM.Infrastructure.Services.Authentication
{
    public interface IAuthenticationService
    {
        Task<string> IsAuthenticatedAsync(TokenRequest request);
    }
}
