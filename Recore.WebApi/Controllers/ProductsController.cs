using Microsoft.AspNetCore.Mvc;
using Recore.Service.DTOs.Attachments;
using Recore.Service.DTOs.Products;
using Recore.Service.DTOs.Users;
using Recore.Service.Interfaces;
using Recore.WebApi.Models;

namespace Recore.WebApi.Controllers;

public class ProductsController : BaseController
{
    private readonly IProductService productService;
    private readonly IAttachmentService attachmentService;
    public ProductsController(IProductService productService, IAttachmentService attachmentService)
    {
        this.productService = productService;
        this.attachmentService = attachmentService;
    }

    [HttpPost("create")]
    public async Task<IActionResult> PostAsync(ProductCreationDto dto)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await this.productService.AddAsync(dto)
        });

    [HttpPost("image-upload")]
    public async Task<IActionResult> ImageUploadAsync(long productId, [FromForm]AttachmentCreationDto dto)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await this.attachmentService.UploadAsync(dto)
        });
}
