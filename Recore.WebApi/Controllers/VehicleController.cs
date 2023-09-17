using Recore.WebApi.Models;
using Microsoft.AspNetCore.Mvc;
using Recore.Service.Interfaces;
using Recore.Service.DTOs.Vehicles;

namespace Recore.WebApi.Controllers;

public class VehicleController : BaseController
{
    private readonly IVehicleService vehicleService;
    public VehicleController(IVehicleService vehicleService)
    {
        this.vehicleService = vehicleService;
    }

    [HttpPost("Set")]
    public async Task<IActionResult> PostAsync(VehicleCreationDto vehicleCreation)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await this.vehicleService.AddAsync(vehicleCreation)
        });

    [HttpPut("update")]
    public async Task<IActionResult> PutAsync(VehicleUpdateDto vehicleUpdate)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await this.vehicleService.ModifyAsync(vehicleUpdate)
        });

    [HttpDelete("delete")]
    public async Task<IActionResult> DeleteAsync(long id)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await this.vehicleService.RemoveAsync(id)
        });

    [HttpGet("get-all")]
    public async Task<IActionResult> GetAllAsync()
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await this.vehicleService.RetrieveAllAsync()
        });

    [HttpGet("get/{id:long}")]
    public async Task<IActionResult> GetByIdAsync(long id)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await this.vehicleService.RetrieveByIdAsync(id)
        });
}
