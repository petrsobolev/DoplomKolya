using System.Collections.Generic;

namespace Diplom.Models.Entities
{
    public class User : BaseEntity
    {
        public string email { get; set; }
        public string phoneNumber { get; set; }
        public virtual List<CreditCard> creditCardId { get; set; }
        public virtual ICollection<Tickets> tickets { get; set; }
        
    }
}