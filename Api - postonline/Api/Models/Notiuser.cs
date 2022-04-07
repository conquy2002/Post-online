namespace Api.Models
{
    public class Notiuser
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string? Body { get; set; }
        public string? Name { get; set; }
        public bool seened { get; set; } = false;
        public int SenderId { get; set; }
        public string CreatedDate { get; set; }
    }
}
