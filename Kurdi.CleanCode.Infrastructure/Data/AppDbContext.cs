using Microsoft.EntityFrameworkCore;
using Kurdi.CleanCode.Core.Entities;
using Kurdi.CleanCode.Core.Entities.StockAggregate;
using Microsoft.Extensions.Configuration;

namespace Kurdi.CleanCode.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        private readonly IConfiguration _configuration;

        public AppDbContext(DbContextOptions<AppDbContext> options, IConfiguration configuration) : base(options)
        {
            _configuration = configuration;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            // connect to postgres with connection string from app settings
            options.UseNpgsql(_configuration.GetConnectionString("WebApiDatabase"));
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<StockItemDetails>().HasKey(details => new { details.LanguageCode, details.Sku });
        }
        //protected override void OnConfiguring(DbContextOptionsBuilder options)
        //       => options.UseMySQL(configuration["db_conn"]);
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<StockItem> StockItems { get; set; }
        public DbSet<StockItemDetails> StockItemDetails { get; set; }
    }
}
/***
    sudo dotnet ef migrations add InitialModel --context AppDbContext -p ../Kurdi.CleanCode.Infrastructure/Kurdi.CleanCode.Infrastructure.csproj -o Data/Migrations
    sudo dotnet ef database update  --context AppDbContext -p ../Kurdi.CleanCode.Infrastructure/Kurdi.CleanCode.Infrastructure.csproj 
**/

