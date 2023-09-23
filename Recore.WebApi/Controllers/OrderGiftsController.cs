using Recore.WebApi.Models;
using Microsoft.AspNetCore.Mvc;
using Recore.Service.Interfaces;
using Recore.Service.DTOs.Orders;
using Recore.Domain.Configurations;

namespace Recore.WebApi.Controllers;

public class OrderGiftsController: BaseController
{
    private readonly IOrderGiftService orderGiftService;
    public OrderGiftsController(IOrderGiftService orderGiftService)
    {
        this.orderGiftService = orderGiftService;
    }

    [HttpPost("create")]
    public async Task<IActionResult> PostAsync(OrderGiftCreationDto dto)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await this.orderGiftService.AddAsync(dto)
        });


    [HttpPut("update")]
    public async Task<IActionResult> PutAsync(OrderGiftUpdateDto dto)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await this.orderGiftService.ModifyAsync(dto)
        });


    [HttpDelete("delete/{id:long}")]
    public async Task<IActionResult> DeleteAsync(long id)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await this.orderGiftService.RemoveAsync(id)
        });


    [HttpGet("get/{id:long}")]
    public async Task<IActionResult> GetByIdAsync(long id)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await this.orderGiftService.RetrieveByIdAsync(id)
        });


    [HttpGet("get-all")]
    public async Task<IActionResult> GetAllAsync([FromQuery] PaginationParams @params)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await this.orderGiftService.RetrieveAllAsync(@params)
        });
}
