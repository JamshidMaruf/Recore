using AutoMapper;
using Newtonsoft.Json;
using Recore.Service.Helpers;
using Recore.Service.Exceptions;
using Recore.Service.Extensions;
using Recore.Service.Interfaces;
using Recore.Data.IRepositories;
using Recore.Domain.Configurations;
using Microsoft.EntityFrameworkCore;
using Recore.Service.DTOs.Countries;
using Recore.Domain.Entities.Addresses;


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

		string path = PathHelper.CountryPath;
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
        var country = await this.repository.SelectAsync(r => r.Id.Equals(id))
            ?? throw new NotFoundException("This country is not found");

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
