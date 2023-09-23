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
    ValueTask<IEnumerable<ProductResultDto>> RetrieveAllAsync(PaginationParams @params);
    ValueTask<IEnumerable<ProductResultDto>> RetrieveAllAsync();
    ValueTask<IEnumerable<ProductResultDto>> RetrieveAllAsync(long categoryId);
    ValueTask<ProductResultDto> IncreaseQuantityAsync(long productId, double quantity);
    ValueTask<ProductResultDto> ImageUploadAsync(long productId, AttachmentCreationDto dto);
    ValueTask<ProductResultDto> ModifyImageAsync(long productId, AttachmentCreationDto dto);
    ValueTask<ProductResultDto> DefineSaleCountAsync(long productId);
    ValueTask<ProductResultDto> SetTopCountAsync(long productId, int saleCount);
    ValueTask<ProductResultDto> SetDiscountAsync(long productId, int discount);
}