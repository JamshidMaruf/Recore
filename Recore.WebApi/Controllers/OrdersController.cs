using Recore.WebApi.Models;
using Microsoft.AspNetCore.Mvc;
using Recore.Service.Interfaces;
using Recore.Service.DTOs.Orders;
using Recore.Domain.Configurations;

namespace Recore.WebApi.Controllers;

public class OrdersController : BaseController
{
    private readonly IOrderService orderService;
    public OrdersController(IOrderService orderService)
    {
        this.orderService = orderService;
    }

    [HttpPost("create")]
    public async Task<IActionResult> PostAsync(OrderCreationDto dto)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await this.orderService.AddAsync(dto)
        });


    [HttpPut("update")]
    public async Task<IActionResult> PutAsync(OrderUpdateDto dto)
       => Ok(new Response
       {
           StatusCode = 200,
           Message = "Success",
           Data = await this.orderService.ModifyAsync(dto)
       });


    [HttpDelete("delete/{id:long}")]
    public async Task<IActionResult> DeleteAsync(long id)
       => Ok(new Response
       {
           StatusCode = 200,
           Message = "Success",
           Data = await this.orderService.RemoveAsync(id)
       });


    [HttpGet("get/{id:long}")]
    public async Task<IActionResult> GetByIdAsync(long id)
       => Ok(new Response
       {
           StatusCode = 200,
           Message = "Success",
           Data = await this.orderService.RetrieveByIdAsync(id)
       });


    [HttpGet("get-all")]
    public async Task<IActionResult> GetAllAsync(PaginationParams @params)
       => Ok(new Response
       {
           StatusCode = 200,
           Message = "Success",
           Data = await this.orderService.RetrieveAllAsync(@params)
       });
}