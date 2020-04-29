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
        public async Task<ActionResult> createTicket([FromBody] Tickets ticket)
        {
            try {

                _dbContext.ticket.Add(ticket);
                await _dbContext.SaveChangesAsync();
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
          
        }

        [HttpPost]
        public dynamic checkedTicket([FromBody] Tickets checkTicket)
        {
            Tickets hasCurrentTicket = _dbContext.ticket.FirstOrDefault(ticket => ticket.id == checkTicket.id);
            var untilDate = hasCurrentTicket.endDateTime - hasCurrentTicket.buyDateTime;
            if(hasCurrentTicket == null)
            {
                return BadRequest();
            }
            else
            {
                if (untilDate >0)
                {
                    var isValidResponse = new IsValidResponse();
                    isValidResponse.isValid = true;
                    isValidResponse.message = "Успешно проверено";
                    return isValidResponse;
                }
                else if(untilDate <=0)
                {
                    hasCurrentTicket.isValid = false;
                    _dbContext.ticket.Update(hasCurrentTicket);
                    var isValidResponse = new IsValidResponse();
                    isValidResponse.isValid = false;
                    isValidResponse.message = "Билет не валдиный";
                    return isValidResponse;
              
                }
                else
                {
                    return BadRequest();
                }
            }
        }

    }
}