using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MadPay724.Repository.Infrastructure
{
    public abstract class Repository<TEntity>:IRepository<TEntity>, IDisposable where TEntity:class
    {
        #region Ctor
        private readonly DbContext _context;
        private readonly DbSet<TEntity> _dbSet;
        public Repository(DbContext context)
        {
            this._context = context;
            this._dbSet = _context.Set<TEntity>();
        }
        #endregion

        #region NormalMethod
        public void Insert(TEntity entity)
        {
            if (entity == null)
                throw new ArgumentException("Not entity exists for your expression's delete");
            this._dbSet.Add(entity);
        }

        public void Update(TEntity entity)
        {
            if (entity == null)
                throw new ArgumentException("Not entity exists for update");
            this._dbSet.Update(entity);
        }

        public void Delete(object id)
        {
            var entity = GetById(id);
            if (entity == null)
                throw new ArgumentException("Not id exists for delete");
            this._dbSet.Remove(entity);
        }

        public void Delete(TEntity entity)
        {
            if (entity == null)
                throw new ArgumentException("Not entity exists for delete");
            this._dbSet.Remove(entity);
        }

        public void Delete(Expression<Func<TEntity, bool>> where)
        {
            IEnumerable<TEntity> entities = this._dbSet.Where(where).AsEnumerable();
            if (entities == null)
                throw new ArgumentException("Not entity exists for your expression's delete");
            foreach (TEntity item in entities)
            {
                this._dbSet.Remove(item);
            }
        }

        public TEntity GetById(object id) => _dbSet.Find(id);

        public IEnumerable<TEntity> GetAll() => _dbSet.AsEnumerable();

        public TEntity Get(Expression<Func<TEntity, bool>> where) => this._dbSet.Where(where).FirstOrDefault();
        public IEnumerable<TEntity> GetMany(Expression<Func<TEntity, bool>> where) => this._dbSet.Where(where).AsEnumerable();
        #endregion

        #region AsyncMethod
        public async Task InsertAsync(TEntity entity)
        {
            if (entity == null)
                throw new ArgumentException("Not entity exists for InsertAsync");
            await this._dbSet.AddAsync(entity);
        }
        public async Task<TEntity> GetByIdAsync(object id)=> await this._dbSet.FindAsync(id);
        public async Task<IEnumerable<TEntity>> GetAllAsync() => await this._dbSet.ToListAsync();
        public async Task<TEntity> GetAsycn(Expression<Func<TEntity, bool>> where) => await this._dbSet.Where(where).FirstOrDefaultAsync();
        public async Task<IEnumerable<TEntity>> GetManyAsync(Expression<Func<TEntity, bool>> where) => await this._dbSet.Where(where).ToListAsync();
        #endregion

        #region Dispose
        private bool disposedValue = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    this._context.Dispose();
                }
                disposedValue = true;
            }
        }
        ~Repository()
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
