
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
            builder.Services.AddDbContext<GescoDbContext>();
            //builder.Services.AddScoped<IGlobalRepository<Produit>, GlobalRepositoryImpl>();
            //builder.Services.AddDbContext<EFEventDbContext>(optionsBuilder => optionsBuilder.UseSqlServer(builder.Configuration.GetConnectionString("EventDbContext")));


            // Build Application

            var app = builder.Build();

            // Configure the HTTP request pipeline.

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}