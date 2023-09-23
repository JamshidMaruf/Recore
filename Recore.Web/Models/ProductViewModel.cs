using Recore.Service.DTOs.Products;
using Recore.Service.DTOs.ProductCategories;

namespace Recore.Web.Models;

public class ProductViewModel
{
    public IEnumerable<ProductResultDto> Products { get; set; }
    public IEnumerable<ProductCategoryResultDto> Categories { get; set; }
    public long CategoryId { get; set; }
    public string Search { get; set; }
}
