namespace Api.Models
{
    public class Transported
    {
        public int TransportID { get; set; }
        public int PayAfterRecieve { get; set; }
        public int PaymentInAdvance { get; set; }

        public ICollection<TransportFee> TransportFees { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
