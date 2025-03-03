using Microsoft.AspNetCore.Mvc;
using Project2_Brydel.Models;
using Project2_Brydel.Repositories;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Project2_Brydel.Data;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;

namespace Project2_Brydel
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Ajout de la connexion MySQL
            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
            builder.Services.AddDbContext<AppDbContext>(options =>
                options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString))
            );

            // Ajout des services
            builder.Services.AddControllersWithViews();
            builder.Services.AddScoped<IRepository<Client>, ClientDAO>();
            builder.Services.AddScoped<IRepository<Commande>, CommandeDAO>();
            builder.Services.AddScoped<IRepository<Produit>, ProduitDAO>();

            var app = builder.Build();

            // Configuration du pipeline HTTP
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
