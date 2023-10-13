using Recore.WebApi.Models;
using Microsoft.AspNetCore.Mvc;
using Recore.Service.Interfaces;
using Recore.Domain.Configurations;
using Recore.Service.DTOs.Products;
using Recore.Service.DTOs.Attachments;

namespace Recore.WebApi.Controllers;

public class ProductsController : BaseController
{
    private readonly IProductService productService;
    public ProductsController(IProductService productService)
    {
        this.productService = productService;
    }

    [HttpPost("create")]
    public async Task<IActionResult> PostAsync(ProductCreationDto dto)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await this.productService.AddAsync(dto)
        });


    [HttpPut("update")]
    public async Task<IActionResult> PutAsync(ProductUpdateDto dto)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await this.productService.ModifyAsync(dto)
        });


    [HttpDelete("delete/{id:long}")]
    public async Task<IActionResult> DeleteAsync(long id)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await this.productService.RemoveAsync(id)
        });


    [HttpGet("get/{id:long}")]
    public async Task<IActionResult> GetByIdAsync(long id)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await this.productService.RetrieveByIdAsync(id)
        });


    [HttpGet("get-all")]
    public async Task<IActionResult> GetAllAsync(
        [FromQuery] PaginationParams @params,
        [FromQuery] Filter filter)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await this.productService.RetrieveAllAsync(@params, filter)
        });


    [HttpPost("image-upload")]
    public async Task<IActionResult> ImageUploadAsync(long productId, [FromForm] AttachmentCreationDto dto)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await this.productService.ImageUploadAsync(productId, dto)
        });


    [HttpPost("update-image")]
    public async Task<IActionResult> UpdateImageAsync(long productId, [FromForm] AttachmentCreationDto dto)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await this.productService.ModifyImageAsync(productId, dto)
        });
}
