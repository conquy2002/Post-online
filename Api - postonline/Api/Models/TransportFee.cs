using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api.Models
{
    public class TransportFee
    {
        [Key]
        public int Id { get; set; }
        public string? Weith { get; set; }
        public string? Distance { get; set; }
        public string? Type { get; set; }
        public int? Money { get; set; }

    }
}
