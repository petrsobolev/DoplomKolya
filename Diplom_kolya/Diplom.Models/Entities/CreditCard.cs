using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Diplom.Models.Entities
{
    public class CreditCard:BaseEntity
    {
        public string userPhone { get; set; }
        public string number { get; set; }
        public string validity { get; set; }
        public string paymentPassword { get; set; }
        public int cvc { get; set; }
        [JsonIgnore]
        public virtual List<Tickets> tickets { get; set; }
    }
}
