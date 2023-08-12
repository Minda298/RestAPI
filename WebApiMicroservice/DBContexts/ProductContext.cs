using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiMicroservice.Models;

namespace WebApiMicroservice.DBContexts
{
    public class ProductContext : DbContext
    {
        public ProductContext(DbContextOptions<ProductContext> options) : base(options)
        {
        }
        public DbSet<Products> Products { get; set; }
        public DbSet<Categories> Categories { get; set; }
        public DbSet<Cashier> Cashiers { get; set; }
        public DbSet<Sales> Sales { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Categories>().HasData(
                new Categories
                {
                    Id = 1,
                    Name = "Electronics",
                    Description = "Electronic Items",
                },
                new Categories
                {
                    Id = 2,
                    Name = "Clothes",
                    Description = "Dresses",
                },
                new Categories
                {
                    Id = 3,
                    Name = "Grocery",
                    Description = "Grocery Items",
                }
            );

            modelBuilder.Entity<Cashier>().HasData(
                new Cashier
                {
                    Id = 1,
                    Name = "Sarah",
                    PhoneNumber = "08151520201000"
                },
                new Cashier
                {
                    Id = 2,
                    Name = "Siti",
                    PhoneNumber = "08151520201001"
                }
            );
        }

    }
}
