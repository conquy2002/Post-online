using Api.Data;
using Microsoft.EntityFrameworkCore;

namespace Api.Models
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ApiContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<ApiContext>>()))
            {
                // Look for any movies.
                if (context.Servce.Any())
                {
                    return;   // DB has been seeded
                }

                context.Servce.AddRange(
                    new Servce
                    {
                        Name = "Hưng",
                        Money = 13000,
                        Time = "4/2/2002"
                    },

                    new Servce
                    {
                        Name = "Đông",
                        Money = 12000,
                        Time = "4/2/2002"
                    },

                    new Servce
                    {
                        Name = "Hùng",
                        Money = 16000,
                        Time = "4/2/2002"
                    },

                    new Servce
                    {
                        Name = "Sử",
                        Money = 17000,
                        Time = "4/2/2002"
                    },
                    new Servce
                    {
                        Name = "Nam",
                        Money = 11000,
                        Time = "4/2/2002"
                    }
                );
                // TransportFee
                //if (context.TransportFee.Any())
                //{
                //    return;   // DB has been seeded
                //}

                //context.TransportFee.AddRange(
                //    new TransportFee
                //    {
                //        Weith = "12kg",
                //        Distance = "1km",
                //        Type = "Houseware",
                //        Money = 13000
                //    },

                //    new TransportFee
                //    {
                //        Weith = "2kg",
                //        Distance = "1km",
                //        Type = "Electronice device",
                //        Money = 3000
                //    },

                //    new TransportFee
                //    {
                //        Weith = "14kg",
                //        Distance = "12km",
                //        Type = "Houseware",
                //        Money = 23000
                //    },

                //    new TransportFee
                //    {
                //        Weith = "50kg",
                //        Distance = "23km",
                //        Type = "Electronice device",
                //        Money = 300000
                //    },
                //    new TransportFee
                //    {
                //        Weith = "1kg",
                //        Distance = "24km",
                //        Type = "Decorations",
                //        Money = 25000
                //    }
                //);
                context.SaveChanges();
            }
        }
    }
}
