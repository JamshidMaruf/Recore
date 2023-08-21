using Recore.Data.IRepositories;
using Recore.Data.Repositories;
using Recore.Service.Interfaces;
using Recore.Service.Mappers;
using Recore.Service.Services;

namespace Recore.WebApi.Extensions;

public static class ServicesCollection
{
    public static void AddServices(this IServiceCollection services)
    {
        services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IRegionService, RegionService>();
        services.AddScoped<ICountryService, CountryService>();
        services.AddScoped<IDistrictService, DistrictService>();
        services.AddAutoMapper(typeof(MappingProfile));
    }
}
