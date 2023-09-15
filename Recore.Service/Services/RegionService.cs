using AutoMapper;
using Newtonsoft.Json;
using Recore.Data.IRepositories;
using Recore.Service.Exceptions;
using Recore.Service.Interfaces;
using Recore.Service.DTOs.Regions;
using Recore.Domain.Entities.Addresses;
using Microsoft.EntityFrameworkCore;
using Recore.Service.Extensions;
using Recore.Domain.Configurations;
using Recore.Service.Helpers;

namespace Recore.Service.Services;

public class RegionService : IRegionService
{
    private readonly IMapper mapper;
    private readonly IRepository<Region> repository;
    public RegionService(IRepository<Region> repository, IMapper mapper)
    {
        this.repository = repository;
        this.mapper = mapper;
    }

	public async ValueTask<bool> SetAsync()
	{
		var dbSource = this.repository.SelectAll();
		if (dbSource.Any())
			throw new AlreadyExistException("Regions are already exist");
		
		string path =PathHelper.RegionPath;

		var source = File.ReadAllText(path);
		var regions = JsonConvert.DeserializeObject<IEnumerable<RegionCreationDto>>(source);

		foreach (var region in regions)
		{
			var mappedRegion = this.mapper.Map<Region>(region);
			await this.repository.CreateAsync(mappedRegion);
			await this.repository.SaveAsync();
		}
		return true;
	}

	public async ValueTask<RegionResultDto> RetrieveByIdAsync(long id)
    {
        var region = await this.repository.SelectAsync(r => r.Id.Equals(id), includes: new[] { "Country" })
            ?? throw new NotFoundException("This region is not found");

        var mappedRegion = this.mapper.Map<RegionResultDto>(region);
        return mappedRegion;
    }

    public async ValueTask<IEnumerable<RegionResultDto>> RetrieveAllAsync(PaginationParams @params)
    {
        var regions = await this.repository.SelectAll(includes: new[] { "Country" })
            .ToPaginate(@params)
			.ToListAsync();
        var result = this.mapper.Map<IEnumerable<RegionResultDto>>(regions);
        return result;
    }
}
