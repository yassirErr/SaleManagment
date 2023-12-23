
using Microsoft.EntityFrameworkCore;
using SaleManagment.Shared;

namespace SaleManagment.Server.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>().HasData(
                    new Order
                    {
                        Id = 1,
                        Name = "New York Building 1",
                        State = "NY"
                    },
                    new Order
                    {
                        Id = 2,
                        Name = "California Hotel AJK"
                        ,
                        State = "CA"
                    }
                );

            modelBuilder.Entity<Window>().HasData(
                    new Window
                    {
                        Id = 1,
                        Name = "GLB",
                        QuantityOfWindows = 3,
                        TotalSubElements = 2,
                     
                    },
                    new Window
                    {
                        Id = 2,
                        Name = "C Zone 5",
                        QuantityOfWindows = 2,
                        TotalSubElements = 1,
                 
                    }
                );


            modelBuilder.Entity<SubElement>().HasData(
                    new SubElement
                    {
                        Id = 1,
                        Element = 1,
                        Type = "Door",
                        Width = 1400,
                        Height = 2200,
                    
                    },
                    new SubElement
                    {
                        Id = 2,
                        Element = 1,
                        Type = "windo",
                        Width = 1400,
                        Height = 2200,
                    
                    }
                );
        }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Window> Windows { get; set; }
        public DbSet<SubElement> SubElements { get; set; }
    }
}

