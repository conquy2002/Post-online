using System.ComponentModel.DataAnnotations;

namespace Api.Models
{
    public class Products
    {
        [Key]
        public int Id { get; set; }
        public int UserId { get; set; }
        public string? Name { get; set; }
        public int Number { get; set; }
        public string? TransportFee { get; set; }
        public int Weith { get; set; }
        public string? Code_orders { get; set; }
        public string? Servce { get; set; }
        public string? FEE_PAYER { get; set; }
        public string? REQUEST_PICK_UP { get; set; }
        public string? RecipientName { get; set; }
        public string? RecipientPhone { get; set; }
        public string? RecipientAddress { get; set; }
        public string? SenderName { get; set; }
        public string? SendertPhone { get; set; }
        public string? SenderAddress { get; set; }
        public int Total_charge { get; set; }
        public string? StartTime { get; set; }
        public int Month { get; set; }

        public string? status { get; set; }
    }
}
