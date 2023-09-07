using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

public class Startup
{
    // Other configurations

    public void ConfigureServices(IServiceCollection services)
    {
        // ...

        // Configure the DbContext to use PostgreSQL
        services.AddDbContext<ApplicationDbContext>(options =>
        {
            var configuration = Configuration.GetConnectionString("DefaultConnection");
            options.UseNpgsql(configuration);
        });

        // ...
    }
}
