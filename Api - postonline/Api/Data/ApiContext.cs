﻿#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Api.Models;

namespace Api.Data
{
    public class ApiContext : DbContext
    {
        public ApiContext (DbContextOptions<ApiContext> options)
            : base(options)
        {
        }

        public DbSet<Api.Models.User> User { get; set; }

        public DbSet<Api.Models.Recipient> Recipient { get; set; }

        public DbSet<Api.Models.Servce> Servce { get; set; }

        public DbSet<Api.Models.TransportFee> TransportFee { get; set; }

        public DbSet<Api.Models.postaddress> postaddress { get; set; }

        public DbSet<Api.Models.Products> Products { get; set; }

        public DbSet<Api.Models.Notiuser> Notiuser { get; set; }
    }
}
