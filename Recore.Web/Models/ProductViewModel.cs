using Recore.Service.DTOs.ProductCategories;
using Recore.Service.DTOs.Products;

namespace Recore.Web.Models;

public class ProductViewModel
{
    public IEnumerable<ProductResultDto> Products { get; set; }
    public IEnumerable<ProductCategoryResultDto> Categories { get; set; }
}
