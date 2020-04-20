using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Diplom.Data;
using Diplom.Domain.Contracts;
using Diplom.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Diplom_kolya.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
       
        private readonly ILogger<UserController> _logger;
        private ApplicationDbContext _dbContext;
        private IRepository<User> _userRepository;

        public UserController(ILogger<UserController> logger
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

        [HttpPost]
        public ActionResult createUsert([FromBody] User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            else
            {
                _dbContext.users.Add(user);
                return Ok();
            }
        }

        [HttpPost]
        public object getCurrentUser([FromBody] string email)
        {
            var currentUser = _dbContext.users.FirstOrDefault(x => x.email == email);
            if(currentUser == null)
            {
                return BadRequest();
            }
            return currentUser;
        }

       
    }
}