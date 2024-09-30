using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace bruhBruh.Models
{
    public class FruitContext : DbContext
    {
        public FruitContext(DbContextOptions<FruitContext> options) : base(options)
        { }
        public DbSet<Fruits> newFruit { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Fruits>().HasData(
            new Fruits
            {
                Name = "Apple",
                Color = "Red",
                Size = "Small",
                Value = 2
            },
            new Fruits
            {
                Name = "Banana",
                Color = "Yellow",
                Size = "Long",
                Value = 3
            },
            new Fruits
            {
                Name = "Mango",
                Color = "Greenish",
                Size = "Medium",
                Value = 2
            }
            );
        }
    }
}
