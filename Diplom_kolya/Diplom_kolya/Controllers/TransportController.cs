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
    public class TransportController : ControllerBase
    {
        private ApplicationDbContext _dbContext;

        public TransportController(ILogger<TransportController> logger
        , ApplicationDbContext dbContext
        , IRepository<Transport> userRepository)
        {
            _dbContext = dbContext;
        }

        [HttpGet("{transport}")]
        public dynamic getTransportByType([FromRoute] string transport)
        {
            List<Transport> transportByType = _dbContext.transport.Where(x => x.transport == transport).ToList();
            return transportByType;
        }

        
      
    }
}