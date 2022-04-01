using System.ComponentModel.DataAnnotations;
namespace Api.Models
{
    public class postaddress
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int Address { get; set; }
        public string Link { get; set; }
    }
}
