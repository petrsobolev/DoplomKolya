using System;
using System.Collections.Generic;
using System.Text;

namespace Diplom.Models.Entities
{
    public class CreditCard:BaseEntity
    {
        public string cardName { get; set; }
        public int number { get; set; }
        public string validity { get; set; }
        public int CVC { get; set; }
        public User user { get; set; }
    }
}
