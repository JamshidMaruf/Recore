using Recore.WebApi.Models;
using Microsoft.AspNetCore.Mvc;
using Recore.Service.Interfaces;
using Recore.Domain.Configurations;

namespace Recore.WebApi.Controllers;

public class DistrictsController : BaseController
{
    private readonly IDistrictService districtService;
    public DistrictsController(IDistrictService districtService)
    {
        this.districtService = districtService;
    }

    [HttpPost("set")]
    public async Task<IActionResult> PostAsync()
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await this.districtService.SetAsync()
        });


    [HttpGet("get/{id:long}")]
    public async Task<IActionResult> GetByIdAsync(long id)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await this.districtService.RetrieveByIdAsync(id)
        });


    [HttpGet("get-all")]
    public async Task<IActionResult> GetAllAsync([FromQuery] PaginationParams @params)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await this.districtService.RetrieveAllAsync(@params)
        });
}