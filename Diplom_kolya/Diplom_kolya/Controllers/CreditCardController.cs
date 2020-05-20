using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Diplom.Data;
using Diplom.Domain.Contracts;
using Diplom.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Stripe;

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
        public async Task<dynamic> createCreditCard([FromBody] CreditCard creditCard)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            else
            {
                _dbContext.creditCard.Add(creditCard);
                await _dbContext.SaveChangesAsync();
                return creditCard;
            }
        }

        [HttpPost]
        [Route("user_card")]
        public dynamic getUserCreditCards([FromBody] CustomerModel customerModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            else      
            {
                var cards = _dbContext.creditCard.Where(cards => cards.userPhone == customerModel.userPhone && customerModel.paymentPasswrod == cards.paymentPassword);
                return cards;
            }
        }
       
        [HttpDelete]
        [Route("delete_card")]
        public dynamic deleteCard([FromBody] CreditCard creditCard)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            else
            {
                var cards = _dbContext.creditCard.Remove(creditCard);
                _dbContext.SaveChanges();
                return Ok();
            }
        }

        [HttpGet("{phoneNumber}")]
        [Route("is_exist")]
        public dynamic isUserExist([FromRoute] string phoneNumber)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            else
            {
                var cards = _dbContext.creditCard.FirstOrDefault(c => c.userPhone == phoneNumber);
                if(cards != null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

    }
}