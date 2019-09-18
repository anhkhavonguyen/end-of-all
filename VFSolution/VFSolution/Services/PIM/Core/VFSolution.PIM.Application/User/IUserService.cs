using System.Threading.Tasks;

namespace VFSolution.PIM.Application.User
{
    public interface IUserService
    {
        Task<bool> IsValidUserAsync(string username, string password);
    }
}
