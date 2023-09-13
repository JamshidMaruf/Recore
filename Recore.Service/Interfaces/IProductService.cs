using Recore.Domain.Configurations;
using Recore.Service.DTOs.Attachments;
using Recore.Service.DTOs.Products;

namespace Recore.Service.Interfaces;

public interface IProductService
{
    ValueTask<ProductResultDto> AddAsync(ProductCreationDto dto);
    ValueTask<ProductResultDto> ModifyAsync(ProductUpdateDto dto);
    ValueTask<bool> RemoveAsync(long id);
    ValueTask<ProductResultDto> RetrieveByIdAsync(long id);
    ValueTask<IEnumerable<ProductResultDto>> RetrieveAllAsync(PaginationParams @params);
    ValueTask<IEnumerable<ProductResultDto>> RetrieveAllAsync();
    ValueTask<ProductResultDto> IncreaseQuantityAsync(long productId, double quantity);
    ValueTask<ProductResultDto> ImageUploadAsync(long productId, AttachmentCreationDto dto);
    ValueTask<ProductResultDto> ModifyImageAsync(long productId, AttachmentCreationDto dto);
}