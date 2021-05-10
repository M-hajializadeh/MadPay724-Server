using MadPay724.Repository.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace MadPay724.Repository.Infrastructure
{
    public interface IUnitOfWork<TContext>: IDisposable where TContext: DbContext
    {
        void SaveChanges();
        Task<int> SaveChangesAsync();

        IUserRepository UserRepository { get; }
    }
}
