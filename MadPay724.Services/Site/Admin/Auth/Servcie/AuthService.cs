using MadPay724.Common.Helpers;
using MadPay724.Data.DatabaseContext;
using MadPay724.Data.Models;
using MadPay724.Repository.Infrastructure;
using MadPay724.Services.Site.Admin.Auth.Interface;
using System.Threading.Tasks;

namespace MadPay724.Services.Site.Admin.Auth.Servcie
{
    public class AuthService : IAuthServcie
    {
        private readonly IUnitOfWork<AppDbContext> _dbContext;
        public AuthService(IUnitOfWork<AppDbContext> dbContext)
        {
            this._dbContext = dbContext;
        }
        public async Task<User> Register(User user, string password)
        {
            byte[] passwordHash, passwordSalt;
            Utilities.CreatePasswordHash(password, out passwordHash, out passwordSalt);
            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;

            await _dbContext.UserRepository.InsertAsync(user);
            await _dbContext.SaveChangesAsync();
            return user;
        }
        public async Task<User> Login(string userName, string password)
        {
            var user = await _dbContext.UserRepository.GetAsycn(u => u.UserName == userName);
            if (user == null) return null;
            if (Utilities.VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
                return user;
            return null;
        }

    }
}
