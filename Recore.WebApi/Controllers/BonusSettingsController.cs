using Recore.WebApi.Models;
using Microsoft.AspNetCore.Mvc;
using Recore.Service.Interfaces;
using Recore.Domain.Configurations;
using Recore.Service.DTOs.BonusSetting;

namespace Recore.WebApi.Controllers;

public class BonusSettingsController : BaseController
{
    private readonly IBonusSettingService bonusSettingService;
    public BonusSettingsController(IBonusSettingService bonusSettingService)
    {
        this.bonusSettingService = bonusSettingService;
    }

    [HttpPost("create")]
    public async ValueTask<IActionResult> PostAsync(BonusSettingCreationDto dto)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await this.bonusSettingService.AddAsync(dto)
        });


    [HttpPut("update")]
    public async ValueTask<IActionResult> PutAsync(BonusSettingUpdateDto dto)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await this.bonusSettingService.ModifyAsync(dto)
        });


    [HttpDelete("delete/{id:long}")]
    public async ValueTask<IActionResult> DeleteAsync(long id)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await this.bonusSettingService.RemoveAsync(id)
        });


    [HttpGet("get/{id:long}")]
    public async ValueTask<IActionResult> GetByIdAsync(long id)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await this.bonusSettingService.RetrieveByIdAsync(id)
        });


    [HttpGet("get-all")]
    public async ValueTask<IActionResult> GetAllAsync([FromQuery] PaginationParams @params)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await this.bonusSettingService.RetrieveAllAsync(@params)
        });
}