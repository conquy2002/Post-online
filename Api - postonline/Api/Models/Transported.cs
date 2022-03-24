using System.ComponentModel.DataAnnotations;

namespace Api.Models
{
    public class Transported
    {
        [Key]
        public int Id { get; set; }
        public int PayAfterRecieve { get; set; }
        public int PaymentInAdvance { get; set; }

        public ICollection<TransportFee> TransportFees { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
