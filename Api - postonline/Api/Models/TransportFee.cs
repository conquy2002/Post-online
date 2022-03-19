using System.ComponentModel.DataAnnotations.Schema;

namespace Api.Models
{
    public class TransportFee
    {
        public int TransportID { get; set; }
        public string Weith { get; set; }
        public string Distance { get; set; }
        public string Type { get; set; }
        public int TotalFee { get; set; }
        public Transported Transported { get; set; }
    }
}
