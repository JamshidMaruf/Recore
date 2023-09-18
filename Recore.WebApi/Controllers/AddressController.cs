using Microsoft.AspNetCore.Mvc;
using Recore.Domain.Configurations;
using Recore.Service.DTOs.Addresses;
using Recore.Service.Interfaces;
using Recore.WebApi.Models;

namespace Recore.WebApi.Controllers;

public class AddressController : BaseController
{
    private readonly IAddressService addressService;
    public AddressController(IAddressService addressService)
    {
        this.addressService = addressService;
    }

    [HttpPost("create")]
    public async Task<IActionResult> PostAsync(AddressCreationDto dto)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await this.addressService.AddAsync(dto)
        });


    [HttpPut("update")]
    public async Task<IActionResult> PutAsync(AddressUpdateDto dto)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await this.addressService.ModifyAsync(dto)
        });


    [HttpDelete("delete/{id:long}")]
    public async Task<IActionResult> DeleteAsync(long id)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await this.addressService.RemoveAsync(id)
        });


    [HttpGet("get/{id:long}")]
    public async Task<IActionResult> GetByIdAsync(long id)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await this.addressService.RetrieveByIdAsync(id)
        });


    [HttpGet("get-all")]
    public async Task<IActionResult> GetAllAsync([FromQuery] PaginationParams @params)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await this.addressService.RetrieveAllAsync(@params)
        });
}
