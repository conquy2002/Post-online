namespace Api.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public int UserId { get; set; }
        public int ProductId { get; set; }
        public int RecipientId { get; set; }
        public int Amount { get; set; }
        public DateTime SentDate { get; set; }
        public string? Distance { get; set; }
        public string? ShippingStatus { get; set; }
        
        public User? User { get; set; }
        public Product? Product { get; set; }
        public Recipient? Recipient { get; set; }
    }
}
