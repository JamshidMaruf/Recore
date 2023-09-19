using Microsoft.AspNetCore.Mvc;
using Recore.Domain.Configurations;
using Recore.WebApi.Models;
using Recore.Service.Interfaces;
using Recore.Service.DTOs.Payments;

namespace Recore.WebApi.Controllers;

public class PaymentController : BaseController
{
    private readonly IPaymentService paymentService;
    public PaymentController(IPaymentService paymentService)
    {
        this.paymentService = paymentService;
    }

    [HttpPost("create")]
    public async ValueTask<IActionResult> PostAsync(PaymentCreationDto dto)
       => Ok(new Response
       {
           StatusCode = 200,
           Message = "Success",
           Data = await this.paymentService.AddAsync(dto)
       });

    [HttpDelete("delete/{id:long}")]
    public async ValueTask<IActionResult> DeleteAsync(long id)
       => Ok(new Response
       {
           StatusCode = 200,
           Message = "Success",
           Data = await this.paymentService.RemoveAsync(id)
       });

    [HttpPut("update")]
    public async ValueTask<IActionResult> UpdateAsync(PaymentUpdateDto dto)
       => Ok(new Response
       {
           StatusCode = 200,
           Message = "Success",
           Data = await this.paymentService.ModifyAsync(dto)
       });

    [HttpPut("get/{id:long}")]
    public async ValueTask<IActionResult> UpdateAsync(long id)
       => Ok(new Response
       {
           StatusCode = 200,
           Message = "Success",
           Data = await this.paymentService.RetrieveByIdAsync(id)
       });

    [HttpPut("get-all")]
    public async ValueTask<IActionResult> GetAllAsync([FromQuery] PaginationParams @params, Filter filter, [FromQuery] string search)
       => Ok(new Response
       {
           StatusCode = 200,
           Message = "Success",
           Data = await this.paymentService.RetrieveAllAsync(@params, filter, search)
       });
}