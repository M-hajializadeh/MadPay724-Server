using MadPay724.Data.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MadPay724.Data.Infrastructure
{
    public interface IUnitOfWork<TContext>: IDisposable where TContext: DbContext
    {
        void SaveChanges();
        Task<int> SaveChangesAsync();

        IUserRepository UserRepository { get; }
    }
}
