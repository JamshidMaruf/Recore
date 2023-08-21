using Recore.Service.DTOs.Products;

namespace Recore.Service.Interfaces;

public interface IProductService
{
    Task<ProductResultDto> AddAsync(ProductCreationDto dto);
    Task<ProductResultDto> ModifyAsync(ProductUpdateDto dto);
    Task<bool> RemoveAsync(long id);
    Task<ProductResultDto> RetrieveByIdAsync(long id);
    Task<IEnumerable<ProductResultDto>> RetrieveAllAsync();
    Task<ProductResultDto> IncreaseQuantityAsync(long productId, double quantity);
}