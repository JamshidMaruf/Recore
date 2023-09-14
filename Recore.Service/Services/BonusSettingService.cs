using AutoMapper;
using Recore.Data.IRepositories;
using Recore.Service.Exceptions;
using Recore.Service.Extensions;
using Recore.Service.Interfaces;
using Recore.Domain.Configurations;
using Microsoft.EntityFrameworkCore;
using Recore.Domain.Entities.Bonuses;
using Recore.Service.DTOs.BonusSetting;

namespace Recore.Service.Services;

public class BonusSettingService : IBonusSettingService
{
    private readonly IMapper mapper;
    private readonly IRepository<BonusSetting> repository;
    public BonusSettingService(IRepository<BonusSetting> repository, IMapper mapper)
    {
        this.mapper = mapper;
        this.repository = repository;
    }

    public async ValueTask<BonusSettingResultDto> AddAsync(BonusSettingCreationDto dto)
    {
        var mappedBonusSetting = this.mapper.Map<BonusSetting>(dto);
        await this.repository.CreateAsync(mappedBonusSetting);
        await this.repository.SaveAsync();

        return this.mapper.Map<BonusSettingResultDto>(mappedBonusSetting);
    }

    public async ValueTask<BonusSettingResultDto> ModifyAsync(BonusSettingUpdateDto dto)
    {
        var existBonusSetting = await this.repository.SelectAsync(b => b.Id.Equals(dto.Id))
            ?? throw new NotFoundException($"This bonus setting is not found with ID = {dto.Id}");

        var mappedBonusSetting = this.mapper.Map<BonusSetting>(dto);
        this.repository.Update(mappedBonusSetting);
        await this.repository.SaveAsync();

        return this.mapper.Map<BonusSettingResultDto>(mappedBonusSetting);
    }

    public async ValueTask<bool> RemoveAsync(long id)
    {
        var existBonusSetting = await this.repository.SelectAsync(b => b.Id.Equals(id))
            ?? throw new NotFoundException($"This bonus setting is not found with ID = {id}");

        this.repository.Delete(existBonusSetting);
        await this.repository.SaveAsync();
        return true;
    }

    public async ValueTask<BonusSettingResultDto> RetrieveByIdAsync(long id)
    {
        var existBonusSetting = await this.repository.SelectAsync(b => b.Id.Equals(id))
            ?? throw new NotFoundException($"This bonus setting is not found with ID = {id}");
        return this.mapper.Map<BonusSettingResultDto>(existBonusSetting);
    }

    public async ValueTask<IEnumerable<BonusSettingResultDto>> RetrieveAllAsync(PaginationParams @params)
    {
        var bonusSettings = await this.repository.SelectAll()
                            .ToPaginate(@params).ToListAsync();
        var result = this.mapper.Map<IEnumerable<BonusSettingResultDto>>(bonusSettings);
        return result;
    }
}