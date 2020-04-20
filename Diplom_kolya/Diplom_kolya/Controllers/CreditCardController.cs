using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Diplom.Data;
using Diplom.Domain.Contracts;
using Diplom.Models.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Diplom_kolya.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CreditCardController : ControllerBase
    {
        private readonly ILogger<CreditCardController> _logger;
        private ApplicationDbContext _dbContext;
        private IRepository<CreditCard> _crediCarRepository;

        public CreditCardController(ILogger<CreditCardController> logger
        , ApplicationDbContext dbContext
        , IRepository<CreditCard> userRepository)
        {
            _dbContext = dbContext;
            _logger = logger;
            _crediCarRepository = userRepository;
        }

        [HttpPost]
        public ActionResult createCreditCard([FromBody] string email, CreditCard creditCard)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            else
            {
                var currentUser = _dbContext.users.FirstOrDefault(x => x.email == email);
                creditCard.user = currentUser;
                _dbContext.creditCards.Add(creditCard);
                return Ok();
            }
        }

    }
}