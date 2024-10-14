using Microsoft.EntityFrameworkCore;
using System;

namespace bruhBruh.Models
{
    public class VeggieContext : DbContext
    {
        public VeggieContext(DbContextOptions<VeggieContext> options) : base(options)
        { }

        // Define the DbSet for the "Veggie" entity
        public DbSet<veggies> Veggies { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Seed data for the "Veggie" entity
            modelBuilder.Entity<veggies>().HasData(
            new veggies
            {
                
                Name = "Celery",
                Weight = 1,
                Size = "Long",
                Value = 2
            },
            new veggies
            {
                
                Name = "Green Pepper",
                Weight=2,
                Size = "Wide",
                Value = 3
            },
            new veggies
            {
                
                Name = "Habanero",
                Weight = 1,
                Size = "Small",
                Value = 2
            });
        }
    }
}
