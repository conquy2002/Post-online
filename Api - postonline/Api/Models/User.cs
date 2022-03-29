using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Api.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Password{ get; set; }
        public string? Avatar{ get; set; }
        public bool IsAdmin { get; set; } = false;
        public string? Token { get; set; }
        public int Phone{ get; set; }
        public string? Email { get; set; }
        public string? Address { get; set; }

        public ICollection<Order> Orders { get; set; } = new List<Order>();
    }
}
