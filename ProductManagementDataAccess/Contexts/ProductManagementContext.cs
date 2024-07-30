using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ProductManagementDomainLayer.Entities.Concretes;
using System.IO;
using System.Reflection;

namespace ProductManagementDataAccess.Contexts
{
    public class ProductManagementContext : DbContext
    {
        public ProductManagementContext(DbContextOptions<ProductManagementContext> options)
           : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var configurationRoot = new ConfigurationBuilder()
               .SetBasePath(Directory.GetCurrentDirectory())
               .AddJsonFile("AppSettingsForConnectionStrings.json", true, true)
               .Build();

            var connectionString = configurationRoot.GetConnectionString("DefaultConnection") ?? "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=ProductsDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";

            optionsBuilder
                .UseLazyLoadingProxies()
                .UseSqlServer(connectionString);

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly()); // To Apply The Configurations
            base.OnModelCreating(modelBuilder);
        }

        public virtual DbSet<Product> Products { get; set; }
    }
}
