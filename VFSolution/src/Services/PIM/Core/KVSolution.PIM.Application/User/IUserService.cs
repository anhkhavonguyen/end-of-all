using System.Threading.Tasks;

namespace KVSolution.PIM.Application.User
{
    public interface IUserService
    {
        Task<bool> IsValidUserAsync(string username, string password);
    }
}
