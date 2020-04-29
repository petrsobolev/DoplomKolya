using System;
using System.Collections.Generic;
using System.Text;

namespace Diplom.Models.Entities
{
    public class Transport:BaseEntity
    {
        public string transport { get; set; }
        public string routeNum { get; set; }
    }
}