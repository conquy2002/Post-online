using System.ComponentModel.DataAnnotations;

namespace Api.Models
{
    public class Recipient
    {
        [Key]
        public int Id { get; set; }
        public int UserID { get; set; }
        public string? Name { get; set; }
        public string? Address { get; set; }
        public int Phone { get; set; }

        public string? City { get; set; }
        public string? District { get; set; }
        public string? Ward { get; set; }
    }
}
