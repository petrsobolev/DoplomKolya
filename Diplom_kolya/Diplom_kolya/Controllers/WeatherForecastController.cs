using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Diplom.Data;
using Diplom.Domain.Contracts;
using Diplom.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Diplom_kolya.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
       
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;
        private ApplicationDbContext _dbContext;
        private IRepository<User> _userRepository;

        public WeatherForecastController(ILogger<WeatherForecastController> logger
            , ApplicationDbContext dbContext
            , IRepository<User> userRepository)
        {
            _dbContext = dbContext;
            _logger = logger;
            _userRepository = userRepository;
        }

        [HttpGet]
        public ActionResult Get()
        {
            _userRepository.GetAll();
            return Ok();
        }
    }
}