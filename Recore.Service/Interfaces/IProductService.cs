using Recore.Domain.Configurations;
using Recore.Service.DTOs.Attachments;
using Recore.Service.DTOs.Products;

namespace Recore.Service.Interfaces;

public interface IProductService
{
    Task<ProductResultDto> AddAsync(ProductCreationDto dto);
    Task<ProductResultDto> ModifyAsync(ProductUpdateDto dto);
    Task<bool> RemoveAsync(long id);
    Task<ProductResultDto> RetrieveByIdAsync(long id);
    Task<IEnumerable<ProductResultDto>> RetrieveAllAsync(PaginationParams @params);
    Task<IEnumerable<ProductResultDto>> RetrieveAllAsync();
    Task<ProductResultDto> IncreaseQuantityAsync(long productId, double quantity);
    Task<ProductResultDto> ImageUploadAsync(long productId, AttachmentCreationDto dto);
    Task<ProductResultDto> ModifyImageAsync(long productId, AttachmentCreationDto dto);
}