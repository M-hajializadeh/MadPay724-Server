using MadPay724.Common.ErrorHandler;
using MadPay724.Data.DatabaseContext;
using MadPay724.Data.DTOs.Site.Admin;
using MadPay724.Data.Models;
using MadPay724.Repository.Infrastructure;
using MadPay724.Services.Site.Admin.Auth.Interface;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace MadPay724.Presentation.Controllers.Site.Admin
{
    [Route("site/admin/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUnitOfWork<AppDbContext> _dbContext;
        private readonly IAuthServcie _authService;
        public AuthController(IUnitOfWork<AppDbContext> unitOfWork, IAuthServcie authService)
        {
            this._dbContext = unitOfWork;
            this._authService = authService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(UserForRegisterDto userForRegisterDto)
        {
            userForRegisterDto.UserName = userForRegisterDto.UserName.ToLower();
            if (await _dbContext.UserRepository.UserExists(userForRegisterDto.UserName)) return BadRequest(new CustomeError 
            {
                Title="خطا",
                Status=false,
                Message="نام کاربری وجود دارد"
            });

            var user = new User()
            {
                UserName= userForRegisterDto.UserName,
                Address = "",
                IsActive = true,
                Name = userForRegisterDto.Name,
                PhoneNumber = userForRegisterDto.PhoneNumber,
                Status = true,
            };
            _ = await _authService.Register(user, userForRegisterDto.Password);
            return StatusCode(201);
        }
    }
}
