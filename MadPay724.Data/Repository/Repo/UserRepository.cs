using MadPay724.Data.DatabaseContext;
using MadPay724.Data.Infrastructure;
using MadPay724.Data.Models;
using MadPay724.Data.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace MadPay724.Data.Repository.Repo
{
    public class UserRepository: Repository<User>, IUserRepository
    {
        private readonly DbContext _dbContext;
        public UserRepository(DbContext dbContext) : base(dbContext)
        {
            _dbContext = (_dbContext ?? (AppDbContext)_dbContext);
        }
    }
}
