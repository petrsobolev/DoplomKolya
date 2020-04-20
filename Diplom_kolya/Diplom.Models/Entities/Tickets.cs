using System;
using System.Collections.Generic;
using System.Text;

namespace Diplom.Models.Entities
{
    public class Tickets :BaseEntity
    {
        public string dateTime { get; set; }
        public int userId { get; set; }
        public User user { get; set; }
        public int transportId { get; set; }
        public Transport Transport { get; set; }
        public bool isValid { get; set; }
    }
}
