using MadPay724.Repository.Repository.Interface;
using MadPay724.Repository.Repository.Repo;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace MadPay724.Repository.Infrastructure
{
    public class UnitOfWork<TContext> : IUnitOfWork<TContext>, IDisposable where TContext : DbContext, new()
    {
        #region Ctor
        protected readonly DbContext _Context;
        public UnitOfWork()
        {
            _Context = new TContext();
        }
        #endregion

        #region PrivateRepository
        private IUserRepository userRepository;
        public IUserRepository UserRepository
        {
            get
            {
                if (userRepository==null)
                {
                    userRepository = new UserRepository(this._Context);
                }
                return userRepository;
            }
        }
        #endregion

        #region Save
        public void SaveChanges()
        {
            _Context.SaveChanges();
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _Context.SaveChangesAsync();
        }
        #endregion

        #region Dispose
        private bool disposedValue=false;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    _Context.Dispose();
                }
                disposedValue = true;
            }
        }
        ~UnitOfWork()
        {
            Dispose(disposing: false);
        }

        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
        #endregion

    }
}
