using Microsoft.EntityFrameworkCore;
using Recore.Data.Contexts;
using Recore.Domain.Entities.Products;
using Recore.Domain.Entities.Users;
using Recore.Service.DTOs.Products;
using Recore.Service.Helpers;
using Recore.Service.Interfaces;

namespace Recore.Service.Services;

public class ProductService : IProductService
{
    public Task<ProductResultDto> AddAsync(ProductCreationDto dto)
    {
        throw new NotImplementedException();
    }

    public Task<ProductResultDto> IncreaseQuantityAsync(long productId, double quantity)
    {
        throw new NotImplementedException();
    }

    public Task<ProductResultDto> ModifyAsync(ProductUpdateDto dto)
    {
        throw new NotImplementedException();
    }

    public Task<bool> RemoveAsync(long id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<ProductResultDto>> RetrieveAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<ProductResultDto> RetrieveByIdAsync(long id)
    {
        throw new NotImplementedException();
    }
}
