using System;
using System.Collections.Generic;
using System.Text;

namespace Diplom.Models.Entities
{
   public class Transport:BaseEntity
    {
        public string transport { get; set; }
        public string routeNum { get; set; }
        public string Operator { get; set; }
        public string routeType { get; set; }
        public string routeName { get; set; }
        public string weekDays { get; set; }
        public virtual List<TransportStops> stops { get; set; }
    }
}
