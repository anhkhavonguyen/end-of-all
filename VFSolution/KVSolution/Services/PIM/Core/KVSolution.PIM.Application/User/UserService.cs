using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using KVSolution.PIM.Persistence;

namespace KVSolution.PIM.Application.User
{
    public class UserService : IUserService
    {
        private readonly KVDbContext _vFDbContext;
        public UserService(KVDbContext vFDbContext)
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
