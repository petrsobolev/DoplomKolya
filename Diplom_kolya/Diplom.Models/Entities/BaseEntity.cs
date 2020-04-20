using System.ComponentModel.DataAnnotations;

namespace Diplom.Models.Entities
{
    public class BaseEntity
    {
        [Key]
        public int Id { get; set; }
    }
}