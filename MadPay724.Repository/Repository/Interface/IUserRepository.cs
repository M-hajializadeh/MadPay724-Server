using MadPay724.Data.Models;
using MadPay724.Repository.Infrastructure;
using System.Threading.Tasks;

namespace MadPay724.Repository.Repository.Interface
{
    public interface IUserRepository:IRepository<User>
    {
        Task<bool> UserExists(string userName);
    }
}
