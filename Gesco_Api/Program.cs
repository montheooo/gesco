
using Entities.Pocos;
using Gesco_DataAccess;
using Gesco_Repository;
using Microsoft.EntityFrameworkCore;

namespace Gesco_Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Create Application builder

            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            builder.Services.AddCors();

            builder.Services.AddDbContext<GescoDbContext>(optionsBuilder => optionsBuilder.UseSqlServer(builder.Configuration.GetConnectionString("GescoDbContext")));

            builder.Services.AddScoped<IGlobalRepository<Produit>, GlobalRepositoryImpl<Produit>>();
            builder.Services.AddScoped<IGlobalRepository<LigneFactureFournisseur>, GlobalRepositoryImpl<LigneFactureFournisseur>>();
            builder.Services.AddScoped<IGlobalRepository<LigneFacture>, GlobalRepositoryImpl<LigneFacture>>();
            builder.Services.AddScoped<IGlobalRepository<Client>, GlobalRepositoryImpl<Client>>();
            builder.Services.AddScoped<IGlobalRepository<Depot>, GlobalRepositoryImpl<Depot>>();

            builder.Services.AddScoped<IinvoicesRepository, InvoicesRepositoryImpl>();

            

            // Build Application

            var app = builder.Build();

            // Configure the HTTP request pipeline.

            app.UseCors(options =>
            {
                options.AllowAnyOrigin();
                options.AllowAnyMethod();
                options.AllowAnyHeader();
            });
          

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}