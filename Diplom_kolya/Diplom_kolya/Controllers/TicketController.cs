using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
    public class TicketController : ControllerBase
    {
        private readonly ILogger<TicketController> _logger;
        private ApplicationDbContext _dbContext;
        private IRepository<Tickets> _crediCarRepository;

        public TicketController(ILogger<TicketController> logger
        , ApplicationDbContext dbContext
        , IRepository<Tickets> userRepository)
        {
            _dbContext = dbContext;
            _logger = logger;
            _crediCarRepository = userRepository;
        }

        [HttpPost]
        public ActionResult createTicket([FromBody] Tickets ticket)
        {
            try {
                _dbContext.tickets.Add(ticket);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
          
        }

        [HttpPut]
        public object checkedTicket([FromBody] string email, int tickedId)
        {
            var currentUser = _dbContext.users.FirstOrDefault(x => x.email == email);
            var hasCurrentTicket = currentUser.tickets.Where(x => x.id == tickedId);
            if(hasCurrentTicket == null)
            {
                return BadRequest();
            }
            else
            {
                if (hasCurrentTicket.FirstOrDefault().isValid)
                {
                    var isValidResponse = new IsValidResponse();
                    isValidResponse.isValid = true;
                    isValidResponse.message = "Успешно проверено";
                    return isValidResponse;
                }
                else
                {
                    var isValidResponse = new IsValidResponse();
                    isValidResponse.isValid = false;
                    isValidResponse.message = "Билет не валдиный";
                    return isValidResponse;
              
                }
            }
        }

    }
}