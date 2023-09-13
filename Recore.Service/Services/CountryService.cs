using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Recore.Data.IRepositories;
using Recore.Domain.Configurations;
using Recore.Domain.Entities.Addresses;
using Recore.Service.DTOs.Countries;
using Recore.Service.DTOs.Regions;
using Recore.Service.Exceptions;
using Recore.Service.Extensions;
using Recore.Service.Interfaces;

namespace Recore.Service.Services;

public class CountryService : ICountryService
{
    private readonly IMapper mapper;
    private readonly IRepository<Country> repository;
    public CountryService(IMapper mapper, IRepository<Country> repository)
    {
        this.mapper = mapper;
        this.repository = repository;
    }
    public async ValueTask<bool> SetAsync()
    {
		var dbSource = this.repository.SelectAll();
        if (dbSource.Any())
            throw new AlreadyExistException("Countries are already exist");

		string path = @"D:\\Lesson\\Recore\\Recore.Shared\\Files\\countries.json";
		var source = File.ReadAllText(path);
		var countries = JsonConvert.DeserializeObject<IEnumerable<CountryCreationDto>>(source);

		foreach (var country in countries)
		{
			var mappedCountry = this.mapper.Map<Country>(country);
			await this.repository.CreateAsync(mappedCountry);
			await this.repository.SaveAsync();
		}
		return true;
    }

    public async ValueTask<CountryResultDto> RetrieveByIdAsync(long id)
    {
        var country = await this.repository.SelectAsync(r => r.Id.Equals(id));
        if (country is null)
            throw new NotFoundException("This country is not found");

        var mappedCountry = this.mapper.Map<CountryResultDto>(country);
        return mappedCountry;
    }
 
    public async ValueTask<IEnumerable<CountryResultDto>> RetrieveAllAsync(PaginationParams @params)
    {
        var countries = await this.repository.SelectAll()
            .ToPaginate(@params)
            .ToListAsync();
        var result = this.mapper.Map<IEnumerable<CountryResultDto>>(countries);
        return result;
    }
}
