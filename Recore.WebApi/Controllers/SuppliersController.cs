using Recore.WebApi.Models;
using Microsoft.AspNetCore.Mvc;
using Recore.Service.Interfaces;
using Recore.Service.DTOs.Suppliers;

namespace Recore.WebApi.Controllers;

public class SuppliersController : BaseController
{
    private readonly ISupplierService supplierService;
    public SuppliersController(ISupplierService supplierService)
    {
        this.supplierService = supplierService;
    }

    [HttpPost("create")]
    public async Task<IActionResult> PostAsync(SupplierCreationDto dto)
    => Ok(new Response
    {
        StatusCode = 200,
        Message = "Success",
        Data = await this.supplierService.AddAsync(dto)
    });

    [HttpPut("update")]
    public async Task<IActionResult> PutAsync(SupplierUpdateDto dto)
   => Ok(new Response
   {
       StatusCode = 200,
       Message = "Success",
       Data = await this.supplierService.ModifyAsync(dto)
   });

    [HttpDelete("delete/{id:long}")]
    public async Task<IActionResult> DeleteAsync(long id)
   => Ok(new Response
   {
       StatusCode = 200,
       Message = "Success",
       Data = await this.supplierService.RemoveAsync(id)
   });

    [HttpGet("get/{id:long}")]
    public async Task<IActionResult> GetByIdAsync(long id)
   => Ok(new Response
   {
       StatusCode = 200,
       Message = "Success",
       Data = await this.supplierService.RetrieveByIdAsync(id)
   });

    [HttpGet("get-all")]
    public async Task<IActionResult> GetAllAsync()
   => Ok(new Response
   {
       StatusCode = 200,
       Message = "Success",
       Data = await this.supplierService.RetrieveAllAsync()
   });
}