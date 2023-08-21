using Microsoft.AspNetCore.Mvc;
using Recore.Service.Interfaces;
using Recore.WebApi.Models;

namespace Recore.WebApi.Controllers;

public class RegionsController : BaseController
{
    private readonly IRegionService regionService;
    public RegionsController(IRegionService regionService)
    {
        this.regionService = regionService;
    }

    [HttpPost("set")]
    public async Task<IActionResult> PostAsync()
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await this.regionService.SetAsync()
        });

    [HttpGet("get/{id:long}")]
    public async Task<IActionResult> GetByIdAsync(long id)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await this.regionService.RetrieveByIdAsync(id)
        });


    [HttpGet("get-all")]
    public async Task<IActionResult> GetAllAsync()
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await this.regionService.RetrieveAllAsync()
        });
}
