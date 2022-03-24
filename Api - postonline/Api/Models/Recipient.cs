using System.ComponentModel.DataAnnotations;

namespace Api.Models
{
    public class Recipient
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public int Phone { get; set; }

        public ICollection<Order> Orders { get; set; }
    }
}
