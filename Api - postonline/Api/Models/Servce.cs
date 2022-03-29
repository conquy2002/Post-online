using System.ComponentModel.DataAnnotations;

namespace Api.Models
{
    public class Servce
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int Money { get; set; }

    }
}
