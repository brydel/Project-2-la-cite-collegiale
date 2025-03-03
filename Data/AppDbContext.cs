using Microsoft.EntityFrameworkCore;
using Project2_Brydel.Models;

namespace Project2_Brydel.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Client> Clients { get; set; }
        public DbSet<Commande> Commandes { get; set; }
        public DbSet<Produit> Produits { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySql(
                    "Server=localhost;Port=3306;Database=ecommerce;User=root;Password=Shaker007!;",
                    new MySqlServerVersion(new Version(8, 0, 34))
                );
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Produit>().HasData(
                new Produit { ProduitId = 1, Nom = "Arduino Uno", Description = "Carte de développement idéale pour débuter", Prix = 29.99m, ImageUrl = "/images/arduino.jpg" },
                new Produit { ProduitId = 2, Nom = "Raspberry Pi 4", Description = "Mini ordinateur puissant avec 4 Go de RAM", Prix = 75.99m, ImageUrl = "/images/raspberry.jpg" },
                new Produit { ProduitId = 3, Nom = "ESP32", Description = "Carte WiFi/Bluetooth pour projets IoT", Prix = 12.99m, ImageUrl = "/images/esp32.jpg" }
            );
        }
    }
}
