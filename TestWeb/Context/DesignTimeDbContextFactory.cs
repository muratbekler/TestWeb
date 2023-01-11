using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace TestWeb.Context
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<MainDbContext>
    {
        public MainDbContext CreateDbContext(string[] args)
        {

            IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            //.AddJsonFile($"appsettings.{configuration. .HostingEnvironment.EnvironmentName}.json", optional: true)
            .AddEnvironmentVariables()
            .Build();

            DbContextOptionsBuilder<MainDbContext> builder = new DbContextOptionsBuilder<MainDbContext>();


#if DEBUG
            string connStr = configuration.GetSection("DefaultConnection").Value;
            Console.WriteLine(connStr);
#endif
#if !DEBUG
            string connStr = configuration.GetSection("DefaultConnection").Value;
#endif
            builder.UseNpgsql(connStr);

            return new MainDbContext(builder.Options);

        }
    }
}
