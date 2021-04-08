using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Model
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        { }

        public DbSet<StorageLocation> StorageLocations { get; set; }
        public DbSet<Item> Items { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StorageLocation>().HasData(
                new StorageLocation
                {
                    Id = 1,
                    Name = "Sahtel"
                },
                new StorageLocation
                {
                    Id = 2,
                    Name = "Kapp"
                },
                new StorageLocation
                {
                    Id = 3,
                    Name = "Riiul"
                },
                new StorageLocation
                {
                    Id = 4,
                    Name = "Garaaz"
                });

            modelBuilder.Entity<Item>().HasData(
                new Item
                {
                    Id = 1,
                    StorageLocationId = 1,
                    Name = "HDMI juhe",
                    SerialNumber = "H1ABC",
                    Comment = "Katki",
                    Color = "Must",
                    Price = 9
                },
                new Item
                {
                    Id = 2,
                    StorageLocationId = 1,
                    Name = "USB juhe",
                    SerialNumber = "USB1",
                    Comment = "Laenatud Antsu käest",
                    Color = "Tumehall",
                    Price = 5
                },
                new Item
                {
                    Id = 3,
                    StorageLocationId = 2,
                    Name = "USB-C juhe",
                    SerialNumber = "USBC",
                    Comment = "Väike värvidefekt ühenduskoha juures",
                    Color = "Must",
                    Price = 6
                });
        }
    }
}
