using Recore.WebApi.Models;
using Microsoft.AspNetCore.Mvc;
using Recore.Service.Interfaces;
using Recore.Service.DTOs.Inventories;

namespace Recore.WebApi.Controllers;

public class InventoriesController : BaseController
{
    private readonly IInventoryService inventoryService;
    public InventoriesController(IInventoryService inventoryService)
    {
        this.inventoryService = inventoryService;
    }


    [HttpPost("create")]
    public async ValueTask<IActionResult> PostAsync(InventoryCreationDto dto)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await this.inventoryService.AddAsync(dto)
        });


    [HttpPut("update")]
    public async ValueTask<IActionResult> PutAsync(InventoryUpdateDto dto)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await this.inventoryService.ModifyAsync(dto)
        });


    [HttpDelete("delete/{id:long}")]
    public async ValueTask<IActionResult> DeleteAsync(long id)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await this.inventoryService.RemoveAsync(id)
        });


    [HttpGet("get/{id:long}")]
    public async ValueTask<IActionResult> GetByIdAsync(long id)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await this.inventoryService.RetrieveByIdAsync(id)
        });


    [HttpGet("get-all")]
    public async ValueTask<IActionResult> GetAllAsync()
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await this.inventoryService.RetrieveAllAsync()
        });

    [HttpGet("get-stock/{productId:long}")]
    public async ValueTask<IActionResult> GetStockAsync(long productId)
       => Ok(new Response
       {
           StatusCode = 200,
           Message = "Success",
           Data = await this.inventoryService.RetrieveStockAsync(productId)
       });
}