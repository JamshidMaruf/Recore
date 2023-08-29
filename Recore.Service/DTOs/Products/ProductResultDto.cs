using Recore.Data.Migrations;
using Recore.Domain.Enums;
using Recore.Service.DTOs.Attachments;
using Recore.Service.DTOs.ProductCategories;

namespace Recore.Service.DTOs.Products;

public class ProductResultDto
{
    public long Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public double Quantity { get; set; }
    public Unit Unit { get; set; }
    public decimal Price { get; set; }
    public int SaleCount { get; set; }
    public bool IsTop { get; set; }
    public int Discount { get; set; }
    public ProductCategoryResultDto Category { get; set; }
    public AttachmentResultDto Attachment { get; set; }
}
