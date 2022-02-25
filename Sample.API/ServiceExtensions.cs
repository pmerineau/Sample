using Microsoft.EntityFrameworkCore;
using Sample.Repo;
using Sample.Repo.Repository;
using Sample.Service;
using Sample.Service.Service;

namespace Sample.API;

public static class ServiceExtensions
{
	
    public static void ConfigureRepository(this IServiceCollection services)
    {
        services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
        services.AddScoped<IClientRepository, ClientRepository>();
    }

    public static void ConfigureService(this IServiceCollection services)
    {
        services.AddScoped<IClientService, ClientService>();
	}

    public static void ConfigureAutoMapper(this IServiceCollection services)
    {
        services.AddAutoMapper(typeof(MappingProfile));
    }

    public static void ConfigureSqlContext(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ApplicationDbContext>(
            options => options.UseSqlServer(configuration.GetConnectionString("sqlConnection")));
    }
		
}
