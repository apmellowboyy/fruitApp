using bruhBruh.Data;
using bruhBruh.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace bruhBruh
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Register ApplicationDbContext for Identity (default connection)
            var identityConnectionString = builder.Configuration.GetConnectionString("VeggieConnection") ?? throw new InvalidOperationException("Connection string 'VeggieConnection' not found.");
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(identityConnectionString));

            builder.Services.AddDatabaseDeveloperPageExceptionFilter();

            // Register Identity services
            builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<ApplicationDbContext>();

            // Register controllers with views
            builder.Services.AddControllersWithViews();

            // Register FruitContext with its own connection string
            var fruitConnectionString = builder.Configuration.GetConnectionString("FruitConnection") ?? throw new InvalidOperationException("Connection string 'FruitConnection' not found.");
            builder.Services.AddDbContext<FruitContext>(options => options.UseSqlServer(fruitConnectionString));

            // Register VeggieContext with its own connection string
            var veggieConnectionString = builder.Configuration.GetConnectionString("VeggieConnection") ?? throw new InvalidOperationException("Connection string 'VeggieConnection' not found.");
            builder.Services.AddDbContext<VeggieContext>(options => options.UseSqlServer(veggieConnectionString));

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
            app.MapRazorPages();

            app.Run();
        }
    }
}
