using Ambev.DeveloperEvaluation.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.Reflection;

namespace Ambev.DeveloperEvaluation.ORM
{

    /// <summary>
    /// Main DbContext for the application. Handles entity sets and mapping.
    /// </summary>
    public class DefaultContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Sale> Sales { get; set; }
        public DbSet<SaleItem> SaleItems { get; set; }

        public DefaultContext(DbContextOptions<DefaultContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Applies all IEntityTypeConfiguration mappings in this assembly
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }
    }

    /// <summary>
    /// Design-time factory for generating migrations and other tooling.
    /// </summary>
    public class DefaultContextFactory : IDesignTimeDbContextFactory<DefaultContext>
    {
        public DefaultContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var builder = new DbContextOptionsBuilder<DefaultContext>();
            var connectionString = configuration.GetConnectionString("DefaultConnection");

            builder.UseNpgsql(
                connectionString,
                b => b.MigrationsAssembly("Ambev.DeveloperEvaluation.WebApi")
            );

            return new DefaultContext(builder.Options);
        }
    }
}