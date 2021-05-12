using MadPay724.Common.ErrorHandler;
using MadPay724.Data.DatabaseContext;
using MadPay724.Data.DTOs.Site.Admin;
using MadPay724.Data.Models;
using MadPay724.Repository.Infrastructure;
using MadPay724.Services.Site.Admin.Auth.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace MadPay724.Presentation.Controllers.Site.Admin
{
    [Authorize]
    [Route("site/admin/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUnitOfWork<AppDbContext> _dbContext;
        private readonly IAuthServcie _authService;
        private readonly IConfiguration _configuration;

        public AuthController(IUnitOfWork<AppDbContext> unitOfWork, IAuthServcie authService, IConfiguration config)
        {
            this._dbContext = unitOfWork;
            this._authService = authService;
            this._configuration=config;
        }

        [AllowAnonymous]
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

        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> Login(UserForLoginDto userForLoginDto)
        {
            userForLoginDto.UserName = userForLoginDto.UserName.ToLower();
            var user = await _authService.Login(userForLoginDto.UserName, userForLoginDto.Password);
            if (user==null) return Unauthorized(new CustomeError
            {
                Title = "خطا",
                Status = false,
                Message = "نام کاربری یا کلمه عبور صحیح نمی باشد"
            });

            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.ID.ToString()),
                new Claim(ClaimTypes.Name, user.UserName)
            };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetSection("AppSettings:Token").Value));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);
            var tokenDescription = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = userForLoginDto.IsRemember ? DateTime.Now.AddDays(1) : DateTime.Now.AddHours(2),
                SigningCredentials = creds
            };
            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescription);

            return Ok(new
            { 
                token=tokenHandler.WriteToken(token)
            });
        }

        [AllowAnonymous]
        [HttpGet("getvalue")]
        public async Task<IActionResult> GetValue()
        {
            return Ok(new CustomeError
            {
                Status = true,
                Title="Acc",
                Message="nothing"
            });
        }

        [HttpGet("getvalues")]
        public async Task<IActionResult> GetValues()
        {
            return Ok(new CustomeError
            {
                Status = true,
                Title = "Acc",
                Message = "nothing"
            });
        }
    }
}
