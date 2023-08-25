using Recore.Service.DTOs.ProductCategories;

namespace Recore.Service.Interfaces;

public interface IProductCategoryService
{
    ValueTask<ProductCategoryResultDto> AddAsync(ProductCategoryCreationDto dto);
    ValueTask<ProductCategoryResultDto> ModifyAsync(ProductCategoryUpdateDto dto);
    ValueTask<bool> RemoveAsync(long id);
    ValueTask<ProductCategoryResultDto> RetrieveByIdAsync(long id);
    ValueTask<IEnumerable<ProductCategoryResultDto>> RetrieveAllAsync();
}