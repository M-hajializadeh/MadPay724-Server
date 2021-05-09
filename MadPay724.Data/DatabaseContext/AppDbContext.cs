using MadPay724.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace MadPay724.Data.DatabaseContext
{
    public class AppDbContext:DbContext
    {
       protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(@"Data Source=.; Initial Catalog=Madpay724-db; Integrated Security=true; MultipleActiveResultSets=true;");
        }

        public DbSet<User> Tbl_User { get; set; }
        public DbSet<Photo> Tbl_Photo { get; set; }
        public DbSet<BankCard> Tbl_BankCard { get; set; }
    }
}
