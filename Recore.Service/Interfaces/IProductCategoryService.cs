using Recore.Service.DTOs.ProductCategories;

namespace Recore.Service.Interfaces;

public interface IProductCategoryService
{
    Task<ProductCategoryResultDto> AddAsync(ProductCategoryCreationDto dto);
    Task<ProductCategoryResultDto> ModifyAsync(ProductCategoryUpdateDto dto);
    Task<bool> RemoveAsync(long id);
    Task<ProductCategoryResultDto> RetrieveByIdAsync(long id);
    Task<IEnumerable<ProductCategoryResultDto>> RetrieveAllAsync();
}