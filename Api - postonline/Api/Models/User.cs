﻿using Microsoft.EntityFrameworkCore;

namespace Api.Models
{
    [Keyless]
    public class User
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string Password{ get; set; }
        public string Avatar{ get; set; }
        public int Phone{ get; set; }
        public string Email { get; set; }
        public string Address { get; set; }

        public ICollection<Order> Orders { get; set; }
    }
}
