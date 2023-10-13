using Recore.WebApi.Models;
using Microsoft.AspNetCore.Mvc;
using Recore.Service.DTOs.Carts;
using Recore.Service.Interfaces;
using Recore.Domain.Configurations;
using Microsoft.AspNetCore.Authorization;

namespace Recore.WebApi.Controllers;

[Authorize]
public class CartItemsController : BaseController
{
    private readonly ICartItemService cartItemService;
    public CartItemsController(ICartItemService cartItemService)
    {
        this.cartItemService = cartItemService;
    }


    [HttpPost("create")]
    public async Task<IActionResult> PostAsync(CartItemCreationDto dto)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await this.cartItemService.AddAsync(dto)
        });


    [HttpPut("update")]
    public async Task<IActionResult> PutAsync(CartItemUpdateDto dto)
       => Ok(new Response
       {
           StatusCode = 200,
           Message = "Success",
           Data = await this.cartItemService.ModifyAsync(dto)
       });


    [HttpDelete("delete/{id:long}")]
    public async Task<IActionResult> DeleteAsync(long id)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await this.cartItemService.RemoveAsync(id)
        });


    [HttpDelete("delete-all/{id:long}")]
    public async Task<IActionResult> DeleteAllAsync(long cartId)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await this.cartItemService.RemoveAllAsync(cartId)
        });


    [HttpGet("get/{id:long}")]
    public async Task<IActionResult> GetAsync(long id)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await this.cartItemService.RetrieveByIdAsync(id)
        });


    [HttpGet("get-list")]
    public IActionResult GetAll([FromQuery] Filter filter, long? cartId = null)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = this.cartItemService.RetrieveAll()
        });
}