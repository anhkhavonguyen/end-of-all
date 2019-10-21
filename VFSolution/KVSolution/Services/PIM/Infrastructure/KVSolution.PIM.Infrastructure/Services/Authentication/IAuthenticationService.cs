using System.Threading.Tasks;
using KVSolution.Common.Config;

namespace KVSolution.PIM.Infrastructure.Services.Authentication
{
    public interface IAuthenticationService
    {
        Task<string> IsAuthenticatedAsync(TokenRequest request);
    }
}
