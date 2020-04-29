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

        [HttpDelete ("{id}")]
        public async Task<dynamic> deleteCreditCard([FromRoute] int cardId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            else
            {
                var currentCreditCard = _dbContext.creditCard.FirstOrDefault(card => card.id == cardId);
                if(currentCreditCard == null)
                {
                    return BadRequest();

                }
                else
                {
                    _dbContext.creditCard.Remove(currentCreditCard);
                    await _dbContext.SaveChangesAsync();
                    return Ok("Vse ok");
                }


            }
        }

        [HttpPost]
        public dynamic getUserCreditCards([FromBody] PhoneNumber phoneNumber)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            else
            {
                var cards = _dbContext.creditCard.Where(cards => cards.phoneNumber == phoneNumber.phoneNumber);
                return cards;
            }
        }

    }
}