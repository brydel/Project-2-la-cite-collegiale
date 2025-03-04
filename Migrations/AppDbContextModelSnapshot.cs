﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Project2_Brydel.Data;

#nullable disable

namespace Project2_Brydel.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.AutoIncrementColumns(modelBuilder);

            modelBuilder.Entity("Project2_Brydel.Models.Client", b =>
                {
                    b.Property<int>("ClientId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("ClientId"));

                    b.Property<string>("Adresse")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Courriel")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Nom")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Prenom")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Telephone")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)");

                    b.HasKey("ClientId");

                    b.ToTable("Clients");
                });

            modelBuilder.Entity("Project2_Brydel.Models.Commande", b =>
                {
                    b.Property<int>("CommandeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("CommandeId"));

                    b.Property<string>("AdresseClient")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.Property<int?>("ClientId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateCommande")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("NomClient")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("PrenomClient")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<int>("ProduitId")
                        .HasColumnType("int");

                    b.Property<int>("Quantite")
                        .HasColumnType("int");

                    b.Property<string>("TelephoneClient")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)");

                    b.HasKey("CommandeId");

                    b.HasIndex("ClientId");

                    b.HasIndex("ProduitId");

                    b.ToTable("Commandes");
                });

            modelBuilder.Entity("Project2_Brydel.Models.Produit", b =>
                {
                    b.Property<int>("ProduitId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("ProduitId"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("varchar(250)");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Nom")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<decimal>("Prix")
                        .HasColumnType("decimal(10,2)");

                    b.HasKey("ProduitId");

                    b.ToTable("Produits");

                    b.HasData(
                        new
                        {
                            ProduitId = 1,
                            Description = "Carte de développement idéale pour débuter",
                            ImageUrl = "/images/arduino.jpg",
                            Nom = "Arduino Uno",
                            Prix = 29.99m
                        },
                        new
                        {
                            ProduitId = 2,
                            Description = "Mini ordinateur puissant avec 4 Go de RAM",
                            ImageUrl = "/images/raspberry.jpg",
                            Nom = "Raspberry Pi 4",
                            Prix = 75.99m
                        },
                        new
                        {
                            ProduitId = 3,
                            Description = "Carte WiFi/Bluetooth pour projets IoT",
                            ImageUrl = "/images/esp32.jpg",
                            Nom = "ESP32",
                            Prix = 12.99m
                        });
                });

            modelBuilder.Entity("Project2_Brydel.Models.Commande", b =>
                {
                    b.HasOne("Project2_Brydel.Models.Client", null)
                        .WithMany("Commandes")
                        .HasForeignKey("ClientId");

                    b.HasOne("Project2_Brydel.Models.Produit", "Produit")
                        .WithMany("Commandes")
                        .HasForeignKey("ProduitId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Produit");
                });

            modelBuilder.Entity("Project2_Brydel.Models.Client", b =>
                {
                    b.Navigation("Commandes");
                });

            modelBuilder.Entity("Project2_Brydel.Models.Produit", b =>
                {
                    b.Navigation("Commandes");
                });
#pragma warning restore 612, 618
        }
    }
}
