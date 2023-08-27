﻿using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Recore.Data.IRepositories;
using Recore.Data.Repositories;
using Recore.Service.Interfaces;
using Recore.Service.Mappers;
using Recore.Service.Services;
using System.Collections;
using System.Text;

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
		services.AddScoped<IAuthService, AuthService>();
		services.AddScoped<IProductService, ProductService>();
		services.AddScoped<IAttachmentService, AttachmentService>();
		services.AddScoped<IProductCategoryService, ProductCategoryService>();
        services.AddAutoMapper(typeof(MappingProfile));
    }

    public static void AddJwt(this IServiceCollection services, IConfiguration configuration)
    {
		services.AddAuthentication(x =>
		{
			x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
			x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
		}).AddJwtBearer(o =>
		{
			var key = Encoding.UTF8.GetBytes(configuration["JWT:Key"]);
			o.SaveToken = true;
			o.TokenValidationParameters = new TokenValidationParameters
			{
				ValidateIssuer = false,
				ValidateAudience = false,
				ValidateLifetime = true,
				ValidateIssuerSigningKey = true,
				ValidIssuer = configuration["JWT:Issuer"],
				ValidAudience = configuration["JWT:Audience"],
				IssuerSigningKey = new SymmetricSecurityKey(key)
			};
		});
	}
}
