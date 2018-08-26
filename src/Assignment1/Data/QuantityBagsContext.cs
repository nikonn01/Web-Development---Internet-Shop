using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Assignment1.Models;
using Microsoft.EntityFrameworkCore;


namespace Assignment1.Data
{
    public class QuantityBagsContext :DbContext
    {
        public QuantityBagsContext(DbContextOptions<QuantityBagsContext> options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<ColourAllocation> ColourAllocations { get; set; }
        public DbSet<Colour> Colours { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Material> Materials { get; set; }
        public DbSet<Size> Sizes { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<AllocateProductOrder> AllocateProductOrders { get; set; }
        public DbSet<Order> Orders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().ToTable("Product");
            modelBuilder.Entity<Category>().ToTable("Category");
            modelBuilder.Entity<ColourAllocation>().ToTable("Colour Allocation");
            
            modelBuilder.Entity<Colour>().ToTable("Colour");
            modelBuilder.Entity<Brand>().ToTable("Brand");
            modelBuilder.Entity<Material>().ToTable("Material");
            modelBuilder.Entity<Size>().ToTable("Size");
            modelBuilder.Entity<User>().ToTable("User");
            modelBuilder.Entity<AllocateProductOrder>().ToTable("Allocate Product Order");
            modelBuilder.Entity<Order>().ToTable("Order");

            

        }
        

    }


}
