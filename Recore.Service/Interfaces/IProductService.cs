using Recore.Domain.Configurations;
using Recore.Service.DTOs.Products;
using Recore.Service.DTOs.Attachments;

namespace Recore.Service.Interfaces;

public interface IProductService
{
    ValueTask<ProductResultDto> AddAsync(ProductCreationDto dto);
    ValueTask<ProductResultDto> ModifyAsync(ProductUpdateDto dto);
    ValueTask<bool> RemoveAsync(long id);
    ValueTask<ProductResultDto> RetrieveByIdAsync(long id);
    ValueTask<IEnumerable<ProductResultDto>> RetrieveAllAsync(PaginationParams @params, Filter filter);
    ValueTask<IEnumerable<ProductResultDto>> RetrieveAllAsync();
    ValueTask<IEnumerable<ProductResultDto>> RetrieveAllAsync(long categoryId);
    ValueTask<ProductResultDto> ImageUploadAsync(long productId, AttachmentCreationDto dto);
    ValueTask<ProductResultDto> ModifyImageAsync(long productId, AttachmentCreationDto dto);
}