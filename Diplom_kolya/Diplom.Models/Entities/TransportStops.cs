using System;
using System.Collections.Generic;
using System.Text;

namespace Diplom.Models.Entities
{
    public class TransportStops : BaseEntity
    {
        public string name { get; set; }
        public double lng { get; set; }
        public double lat{get;set;}
        public virtual List<Transport> transports { get; set; }

    }
}
