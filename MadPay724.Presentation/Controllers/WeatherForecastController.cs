using MadPay724.Data.DatabaseContext;
using MadPay724.Data.Infrastructure;
using MadPay724.Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MadPay724.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        private readonly IUnitOfWork<AppDbContext> _unitOfWork;
        public WeatherForecastController(ILogger<WeatherForecastController> logger, IUnitOfWork<AppDbContext> unitOfWork)
        {
            _logger = logger;
            this._unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<string>>> Get()
        {
            //var user = new User()
            //{
            //    Address = "",
            //    IsActive = true,
            //    Name = "",
            //    PasswordHash = new byte[] { },
            //    PasswordSalt = new byte[] { },
            //    PhoneNumber = "",
            //    Status = true,
            //    UserName = ""
            //};

            //await _unitOfWork.UserRepository.InsertAsync(user);
            //await _unitOfWork.SaveChangesAsync();
            //var model = await _unitOfWork.UserRepository.GetAllAsync();
            return Ok("");
        }
    }
}
