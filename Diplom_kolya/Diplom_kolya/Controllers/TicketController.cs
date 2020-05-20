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

            var newTicket = new Tickets()
            {
                card = _dbContext.creditCard.FirstOrDefault(i => i.id == ticket.card.id),
                transport = _dbContext.transport.FirstOrDefault(t => t.id == ticket.transport.id),
                endDateTime = ticket.endDateTime,
                buyDateTime = ticket.buyDateTime,
                isValid = ticket.isValid
            };

            _dbContext.tickets.Add(newTicket);
            await _dbContext.SaveChangesAsync();
            return Ok("Ticket was created");
          
        }

        [HttpPost]
        [Route("check_ticket")]
        public dynamic checkedTicket([FromBody] Tickets checkTicket)
        {
            Tickets currentTicket = _dbContext.tickets.FirstOrDefault(ticket => ticket.id == checkTicket.id);
            long currentTime = DateTimeOffset.Now.ToUnixTimeMilliseconds();
            var untilDate = currentTicket.endDateTime - currentTime;
            if(currentTicket == null)
            {
                return BadRequest();
            }
            else
            {
                if (untilDate >0)
                    {
                    return currentTicket;
                }
                else if(untilDate <=0)
                {
                    currentTicket.isValid = false;
                    _dbContext.tickets.Update(currentTicket);
                    return currentTicket;
                }
                else
                {
                    return BadRequest();
                }
            }
        }

        [HttpGet ("{creditCardId}")]
        public dynamic getUserTickets([FromRoute] int creditCardId)
        {
            var tickets = _dbContext.tickets.Where(item => item.creditCardId == creditCardId);
            return tickets;
                
        }

    }
}