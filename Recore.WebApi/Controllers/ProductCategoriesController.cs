using Recore.WebApi.Models;
using Microsoft.AspNetCore.Mvc;
using Recore.Service.Interfaces;
using Recore.Service.DTOs.ProductCategories;

namespace Recore.WebApi.Controllers;

public class ProductCategoriesController : BaseController
{
    private readonly IProductCategoryService productCategoryService;
    public ProductCategoriesController(IProductCategoryService productCategoryService)
    {
        this.productCategoryService = productCategoryService;
    }

    [HttpPost("create")]
    public async Task<IActionResult> PostAsync(ProductCategoryCreationDto dto)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await this.productCategoryService.AddAsync(dto)
        });


    [HttpPut("update")]
    public async Task<IActionResult> PutAsync(ProductCategoryUpdateDto dto)
       => Ok(new Response
       {
           StatusCode = 200,
           Message = "Success",
           Data = await this.productCategoryService.ModifyAsync(dto)
       });


    [HttpDelete("delete/{id:long}")]
    public async Task<IActionResult> DeleteAsync(long id)
       => Ok(new Response
       {
           StatusCode = 200,
           Message = "Success",
           Data = await this.productCategoryService.RemoveAsync(id)
       });


    [HttpGet("get/{id:long}")]
    public async Task<IActionResult> GetByIdAsync(long id)
       => Ok(new Response
       {
           StatusCode = 200,
           Message = "Success",
           Data = await this.productCategoryService.RetrieveByIdAsync(id)
       });


    [HttpGet("get-all")]
    public async Task<IActionResult> GetAllAsync()
       => Ok(new Response
       {
           StatusCode = 200,
           Message = "Success",
           Data = await this.productCategoryService.RetrieveAllAsync()
       });
}
