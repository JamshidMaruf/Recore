using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Recore.Data.IRepositories;
using Recore.Domain.Configurations;
using Recore.Domain.Entities.Addresses;
using Recore.Service.DTOs.Addresses;
using Recore.Service.Exceptions;
using Recore.Service.Extensions;
using Recore.Service.Interfaces;

namespace Recore.Service.Services;

public class AddressService : IAddressService
{
    private readonly IMapper mapper;
    private readonly IRepository<Region> regionRepository;
    private readonly IRepository<Address> addressRepository;
    private readonly IRepository<Country> countryRepository;
    private readonly IRepository<District> districtRepository;
    public AddressService(
        IMapper mapper,
        IRepository<Region> regionRepository,
        IRepository<Address> addressRepository,
        IRepository<Country> countryRepository,
        IRepository<District> districtRepository)
    {
        this.mapper = mapper;
        this.regionRepository = regionRepository;
        this.addressRepository = addressRepository;
        this.countryRepository = countryRepository;
        this.districtRepository = districtRepository;
    }

    public async ValueTask<AddressResultDto> AddAsync(AddressCreationDto dto)
    {
        var existRegion = await this.regionRepository.SelectAsync(r => r.Id.Equals(dto.RegionId))
            ?? throw new NotFoundException($"This regionId was not found with {dto.RegionId}");

        var existCountry = await this.countryRepository.SelectAsync(r => r.Id.Equals(dto.CountryId))
            ?? throw new NotFoundException($"This countryId was not found with {dto.CountryId}");

        var existDistrict = await this.districtRepository.SelectAsync(r => r.Id.Equals(dto.DistrictId))
            ?? throw new NotFoundException($"This districtId was not found with {dto.DistrictId}");

        var mappedAddress = this.mapper.Map<Address>(dto);
        await this.addressRepository.CreateAsync(mappedAddress);
        await this.addressRepository.SaveAsync();

        mappedAddress.Region = existRegion;
        mappedAddress.Country = existCountry;
        mappedAddress.District = existDistrict;

        return this.mapper.Map<AddressResultDto>(mappedAddress);
    }

    public async ValueTask<AddressResultDto> ModifyAsync(AddressUpdateDto dto)
    {
        var existAddress = await this.addressRepository.SelectAsync(r => r.Id.Equals(dto.Id))
            ?? throw new NotFoundException($"This id was not found with {dto.Id}");

        var existRegion = await this.regionRepository.SelectAsync(r => r.Id.Equals(dto.RegionId))
            ?? throw new NotFoundException($"This regionId was not found with {dto.RegionId}");

        var existCountry = await this.countryRepository.SelectAsync(r => r.Id.Equals(dto.CountryId))
            ?? throw new NotFoundException($"This countryId was not found with {dto.CountryId}");

        var existDistrict = await this.districtRepository.SelectAsync(r => r.Id.Equals(dto.DistrictId))
            ?? throw new NotFoundException($"This districtId was not found with {dto.DistrictId}");

        existAddress.RegionId = existRegion.Id;
        existAddress.CountryId = existCountry.Id;
        existAddress.DistrictId = existDistrict.Id;

        this.mapper.Map(dto, existAddress);
        this.addressRepository.Update(existAddress);
        await this.addressRepository.SaveAsync();

        existAddress.Region = existRegion;
        existAddress.Country = existCountry;
        existAddress.District = existDistrict;

        return mapper.Map<AddressResultDto>(existAddress);
    }

    public async ValueTask<bool> RemoveAsync(long id)
    {
        var existAddress = await this.addressRepository.SelectAsync(r => r.Id.Equals(id))
            ?? throw new NotFoundException($"This id was not found with {id}");

        this.addressRepository.Delete(existAddress);
        await this.addressRepository.SaveAsync();

        return true;
    }

    public async ValueTask<IEnumerable<AddressResultDto>> RetrieveAllAsync()
    {
        var addresses = await this.addressRepository.SelectAll(includes: new[] { "Country", "Region", "District" })
            .ToListAsync();

        return this.mapper.Map<IEnumerable<AddressResultDto>>(addresses);
    }

    public async ValueTask<IEnumerable<AddressResultDto>> RetrieveAllAsync(PaginationParams @params)
    {
        var addresses = await this.addressRepository.SelectAll(includes: new[] { "Country", "Region", "District" })
            .ToPaginate(@params)
            .ToListAsync();

        return this.mapper.Map<IEnumerable<AddressResultDto>>(addresses);
    }

    public async ValueTask<AddressResultDto> RetrieveByIdAsync(long id)
    {
        var existAddress = await this.addressRepository.SelectAsync(p => p.Id.Equals(id),
            includes: new[] { "Country", "Region", "District" })
            ?? throw new NotFoundException($"This id was not found with {id}");

        return this.mapper.Map<AddressResultDto>(existAddress);
    }
}