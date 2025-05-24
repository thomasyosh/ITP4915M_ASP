using Microsoft.EntityFrameworkCore;

namespace ITP4915M.Data
{

    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
            {
            }

            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder
        .UseLazyLoadingProxies()
        .UseMySql(
            Environment.GetEnvironmentVariable("ConnectionString"),
            ServerVersion.AutoDetect(Environment.GetEnvironmentVariable("ConnectionString"))
        )
        .EnableSensitiveDataLogging(true)
        .EnableDetailedErrors(true);
        
    }
}