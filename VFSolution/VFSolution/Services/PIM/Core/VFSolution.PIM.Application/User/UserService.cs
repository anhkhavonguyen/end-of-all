using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using VFSolution.PIM.Persistence;

namespace VFSolution.PIM.Application.User
{
    public class UserService : IUserService
    {
        private readonly VFDbContext _vFDbContext;
        public UserService(VFDbContext vFDbContext)
        {
            _vFDbContext = vFDbContext;
        }

        public async Task<bool> IsValidUserAsync(string username, string password)
        {
            var user = await _vFDbContext.Users.FirstOrDefaultAsync(x => x.UserName == username && x.Password == password);
            return user != null ? true : false;
        }
    }
}
