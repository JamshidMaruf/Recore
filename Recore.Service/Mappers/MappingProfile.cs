using AutoMapper;
using Recore.Service.DTOs.Users;
using Recore.Service.DTOs.Orders;
using Recore.Service.DTOs.Regions;
using Recore.Service.DTOs.Payments;
using Recore.Domain.Entities.Users;
using Recore.Service.DTOs.Vehicles;
using Recore.Service.DTOs.Products;
using Recore.Domain.Entities.Orders;
using Recore.Service.DTOs.Addresses;
using Recore.Service.DTOs.Countries;
using Recore.Service.DTOs.Suppliers;
using Recore.Service.DTOs.Districts;
using Recore.Service.DTOs.WareHouses;
using Recore.Domain.Entities.Payments;
using Recore.Domain.Entities.Products;
using Recore.Service.DTOs.Inventories;
using Recore.Domain.Entities.Settings;
using Recore.Service.DTOs.Attachments;
using Recore.Domain.Entities.Suppliers;
using Recore.Service.DTOs.BonusSetting;
using Recore.Domain.Entities.Addresses;
using Recore.Domain.Entities.Warehouses;
using Recore.Service.DTOs.InventoryLogs;
using Recore.Domain.Entities.Attachments;
using Recore.Domain.Entities.Inventories;
using Recore.Service.DTOs.ProductCategories;


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
        CreateMap<ProductForRelationDto, Product>().ReverseMap();
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

        //Bonus Setting
        CreateMap<BonusSetting, BonusSettingResultDto>().ReverseMap();
        CreateMap<BonusSettingCreationDto, BonusSetting>().ReverseMap();
        CreateMap<BonusSettingUpdateDto, BonusSetting>().ReverseMap();

        //Vehicle
        CreateMap<Vehicle, VehicleResultDto>().ReverseMap();
        CreateMap<VehicleCreationDto, Vehicle>().ReverseMap();
        CreateMap<VehicleUpdateDto, Vehicle>().ReverseMap();

        //WareHouse 
        CreateMap<Warehouse, WarehouseResultDto>().ReverseMap();
		CreateMap<WareHouseCreationDto, Warehouse>().ReverseMap();
		CreateMap<WareHouseUpdateDto, Warehouse>().ReverseMap();

        //Inventory 
        CreateMap<Inventory, InventoryResultDto>().ReverseMap();
        CreateMap<InventoryCreationDto, Inventory>().ReverseMap();
        CreateMap<InventoryUpdateDto, Inventory>().ReverseMap();

        //Inventory log
        CreateMap<InventoryLog, InventoryResultDto>().ReverseMap();
        CreateMap<InventoryLogCreationDto, InventoryLog>().ReverseMap();
        CreateMap<InventoryLogUpdateDto, InventoryLog>().ReverseMap();

        //Address
        CreateMap<Address, AddressResultDto>().ReverseMap();
        CreateMap<AddressCreationDto, Address>().ReverseMap();
        CreateMap<AddressUpdateDto, Address>().ReverseMap();

        //OrderGift
        CreateMap<OrderGift, OrderGiftResultDto>().ReverseMap();
        CreateMap<OrderGiftCreationDto, OrderGift>().ReverseMap();
        CreateMap<OrderGiftUpdateDto, OrderGift>().ReverseMap();
        
        //Payment
        CreateMap<Payment, PaymentResultDto>().ReverseMap();
        CreateMap<PaymentCreationDto, Payment>().ReverseMap();
        CreateMap<PaymentUpdateDto, Payment>().ReverseMap();
        
        //Order
        CreateMap<Order, OrderResultDto>().ReverseMap();
        CreateMap<OrderCreationDto, Order>().ReverseMap();
        CreateMap<OrderUpdateDto, Order>().ReverseMap();

        //Supplier
        CreateMap<Supplier, SupplierResultDto>().ReverseMap();
        CreateMap<SupplierCreationDto, Supplier>().ReverseMap();
        CreateMap<SupplierUpdateDto, Supplier>().ReverseMap();
    }
}
