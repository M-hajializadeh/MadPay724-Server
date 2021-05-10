using MadPay724.Data.DatabaseContext;
using MadPay724.Data.Models;
using MadPay724.Repository.Infrastructure;
using MadPay724.Repository.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace MadPay724.Repository.Repository.Repo
{
    public class UserRepository: Repository<User>, IUserRepository
    {
        private readonly DbContext _dbContext;
        public UserRepository(DbContext dbContext) : base(dbContext)
        {
            _dbContext ??= (AppDbContext)_dbContext;
        }

        public async Task<bool> UserExists(string userName)
        {
            if (await GetAsycn(u => u.UserName == userName) != null)
                return true;
            return false; 
        }
    }
}
