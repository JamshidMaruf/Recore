using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Recore.Data.IRepositories;
using Recore.Domain.Configurations;
using Recore.Domain.Entities.Addresses;
using Recore.Service.DTOs.Countries;
using Recore.Service.DTOs.Districts;
using Recore.Service.DTOs.Users;
using Recore.Service.Exceptions;
using Recore.Service.Extensions;
using Recore.Service.Helpers;
using Recore.Service.Interfaces;

namespace Recore.Service.Services;

public class DistrictService : IDistrictService
{
    private readonly IMapper mapper;
    private readonly IRepository<District> repository;
    public DistrictService(IMapper mapper, IRepository<District> repository)
    {
        this.mapper = mapper;
        this.repository = repository;
    }

    public async ValueTask<bool> SetAsync()
    {
        var dbSource = this.repository.SelectAll();
        if (dbSource.Any())
            throw new AlreadyExistException("Districts are already exist");
        
		string path =PathHelper.DistrictPath;
		var source = File.ReadAllText(path);
		var districts = JsonConvert.DeserializeObject<IEnumerable<DistrictCreationDto>>(source);

		foreach (var district in districts)
		{
			var mappedDistrict = this.mapper.Map<District>(district);
			await this.repository.CreateAsync(mappedDistrict);
			await this.repository.SaveAsync();
		}
		return true;
    }

    public async ValueTask<DistrictResultDto> RetrieveByIdAsync(long id)
    {
        var district = await this.repository.SelectAsync(r => r.Id.Equals(id), includes: new[] { "Region.Country" })
            ?? throw new NotFoundException("This district is not found");

        var mappedDistrict = this.mapper.Map<DistrictResultDto>(district);
        return mappedDistrict;
    }

    public async ValueTask<IEnumerable<DistrictResultDto>> RetrieveAllAsync(PaginationParams @params)
    {
        var districts = await this.repository.SelectAll(includes: new[] { "Region.Country" })
            .ToPaginate(@params)
			.ToListAsync();
        var result = this.mapper.Map<IEnumerable<DistrictResultDto>>(districts);
        return result;
    }
}
