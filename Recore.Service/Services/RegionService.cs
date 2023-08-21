using AutoMapper;
using Newtonsoft.Json;
using Recore.Data.IRepositories;
using Recore.Service.Exceptions;
using Recore.Service.Interfaces;
using Recore.Service.DTOs.Regions;
using Recore.Domain.Entities.Addresses;
using Microsoft.EntityFrameworkCore;

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

    public async Task<RegionResultDto> RetrieveByIdAsync(long id)
    {
        var region = await this.repository.SelectAsync(r => r.Id.Equals(id));
        if (region is null)
            throw new NotFoundException("This region is not found");

        var mappedRegion = this.mapper.Map<RegionResultDto>(region);
        return mappedRegion;
    }

    public async Task<IEnumerable<RegionResultDto>> RetrieveAllAsync()
    {
        var regions = await this.repository.SelectAll().ToListAsync();
        var result = this.mapper.Map<IEnumerable<RegionResultDto>>(regions);
        return result;
    }

    public async Task<bool> SetAsync()
    {
        string path = @"D:\Lesson\Recore\Recore.Shared\Files\regions.json";
        
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
}
