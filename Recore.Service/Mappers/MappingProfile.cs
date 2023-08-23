using AutoMapper;
using Recore.Domain.Entities.Addresses;
using Recore.Domain.Entities.Attachments;
using Recore.Domain.Entities.Products;
using Recore.Domain.Entities.Users;
using Recore.Service.DTOs.Attachments;
using Recore.Service.DTOs.Countries;
using Recore.Service.DTOs.Districts;
using Recore.Service.DTOs.ProductCategories;
using Recore.Service.DTOs.Products;
using Recore.Service.DTOs.Regions;
using Recore.Service.DTOs.Users;

namespace Recore.Service.Mappers;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        // User
        CreateMap<User, UserResultDto>().ReverseMap();
        CreateMap<UserCreationDto, User>().ReverseMap();
        CreateMap<UserUpdateDto, User>().ReverseMap();

        // Product
        CreateMap<Product, ProductResultDto>().ReverseMap();
        CreateMap<ProductCreationDto, Product>().ReverseMap();
        CreateMap<ProductUpdateDto, Product>().ReverseMap();

        // Product category
        CreateMap<ProductCategory, ProductCategoryResultDto>().ReverseMap();
        CreateMap<ProductCategoryCreationDto, ProductCategory>().ReverseMap();
        CreateMap<ProductCategoryUpdateDto, ProductCategory>().ReverseMap();

        // Country
        CreateMap<Country, CountryCreationDto>().ReverseMap();
        CreateMap<CountryResultDto, Country>().ReverseMap();

        // Region
        CreateMap<Region, RegionCreationDto>().ReverseMap();
        CreateMap<RegionResultDto, Region>().ReverseMap();

        // District
        CreateMap<District, DistrictCreationDto>().ReverseMap();
        CreateMap<DistrictResultDto, District>().ReverseMap();

        // Attachment
        CreateMap<AttachmentResultDto, Attachment>().ReverseMap();
    }
}
