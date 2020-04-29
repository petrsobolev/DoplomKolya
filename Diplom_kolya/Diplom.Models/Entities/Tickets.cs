using System;
using System.Collections.Generic;
using System.Text;

namespace Diplom.Models.Entities
{
    public class Tickets :BaseEntity
    {
        public long endDateTime { get; set; }
        public long buyDateTime { get; set; }
        public int creditCardId { get; set; }
        public virtual CreditCard card { get; set; }
        public int transportId { get; set; }
        public virtual Transport Transport { get; set; }
        public bool isValid { get; set; }
    }
}
