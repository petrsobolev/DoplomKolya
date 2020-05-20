using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Diplom.Models.Entities
{
    public class Transport:BaseEntity
    {
        public string transport { get; set; }
        public string routeNum { get; set; }
        public double cost { get; set; }
        [JsonIgnore]
        public virtual List<Tickets> tickets { get; set; }
    }
}