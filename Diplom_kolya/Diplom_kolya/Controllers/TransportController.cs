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
        private readonly ILogger<TransportController> _logger;
        private ApplicationDbContext _dbContext;
        private IRepository<Transport> _crediCarRepository;

        public TransportController(ILogger<TransportController> logger
        , ApplicationDbContext dbContext
        , IRepository<Transport> userRepository)
        {
            _dbContext = dbContext;
            _logger = logger;
            _crediCarRepository = userRepository;
        }

        [HttpGet("{routeType}")]
        public object getTransportByType([FromRoute] string routeType)
        {
            var transportByType = _dbContext.transports.Where(x => x.routeType == routeType).ToList();
            return transportByType;
        }
    }
}