using MadPay724.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MadPay724.Services.Site.Admin.Auth.Interface
{
    public interface IAuthServcie
    {
        Task<User> Register(User user, string password);
        Task<User> Login(string userName, string password);
    }
}
