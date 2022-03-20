namespace Api.Models
{
    public class Product
    {
        public int Id { get; set; }
        public int TransportId { get; set; }
        public string Name { get; set; }
        public string Weight { get; set; }
        public string Type { get; set; }
        public int Size { get; set; }
        public string Details { get; set; }
        
        public Transported Transported { get; set; }
        public ICollection<Order> Orders { get; set; }
    }
}
