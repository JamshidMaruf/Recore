using Microsoft.AspNetCore.Mvc;
using Recore.Domain.Entities.Products;
using Recore.Service.Interfaces;
using Recore.Web.Models;

namespace Recore.Web.Controllers;

public class ProductsController : Controller
{
    private readonly IProductService productService;
    private readonly IProductCategoryService productCategoryService;
    public ProductsController(IProductService productService, IProductCategoryService productCategoryService)
    {
        this.productService = productService;
        this.productCategoryService = productCategoryService;
    }

    public async Task<IActionResult> Index(long categoryId, string search = null)
    {
        var products = await this.productService.RetrieveAllAsync();
        var categories = await this.productCategoryService.RetrieveAllAsync();

        if(!string.IsNullOrEmpty(search))
        {
            products = products.Where(p => p.Name.Contains(search));
        }

        var viewModel = new ProductViewModel
        {
            Products = products,
            Categories = categories
        };
        return View(viewModel);
    }
}   
