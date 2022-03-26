namespace Api.Models
{
    public class userotp
    {

            public int Id { get; set; }
            public string? Name { get; set; }
            public string? Avatar { get; set; }
            public int? Phone { get; set; }
            public string? Email { get; set; }
            public string? Address { get; set; }

            public ICollection<Order> Orders { get; set; } = new List<Order>();
        
    }
}
