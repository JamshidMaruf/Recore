//using Microsoft.EntityFrameworkCore;
//using Recore.Data.Contexts;
//using Recore.Domain.Entities.Products;
//using Recore.Domain.Entities.Users;
//using Recore.Service.DTOs.Products;
//using Recore.Service.Helpers;
//using Recore.Service.Interfaces;

//namespace Recore.Service.Services;

//public class ProductService : IProductService
//{
//    private readonly AppDbContext appDbContext = new AppDbContext();
//    private readonly ProductCategoryService productCategoryService = new ProductCategoryService();

//    public async Task<Response<ProductResultDto>> CreateAsync(ProductCreationDto dto)
//    {
//        var categoryResult = await productCategoryService.GetByIdAsync(dto.CategoryId); 
//        if (categoryResult.StatusCode != 200)
//            return new Response<ProductResultDto>
//            {
//                StatusCode = categoryResult.StatusCode,
//                Message = categoryResult.Message
//            };

//        var mappedProduct = new Product
//        {
//            Unit = dto.Unit,
//            Name = dto.Name,
//            Price = dto.Price,
//            Quantity = dto.Quantity,
//            CategoryId = dto.CategoryId,
//            Description = dto.Description
//        };

//        var createdProduct = (await appDbContext.Products.AddAsync(mappedProduct)).Entity;
//        await appDbContext.SaveChangesAsync();

//        var result = new ProductResultDto
//        {
//            Id = createdProduct.Id,
//            Unit = createdProduct.Unit,
//            Name = createdProduct.Name,
//            Price = createdProduct.Price,
//            Quantity = createdProduct.Quantity,
//            Description = createdProduct.Description
//        };

//        return new Response<ProductResultDto>
//        {
//            StatusCode = 200,
//            Message = "Success",
//            Data = result
//        };
//    }

//    public async Task<Response<ProductResultDto>> UpdateAsync(ProductUpdateDto dto)
//    {
//        var product = await appDbContext.Products
//            .FirstOrDefaultAsync(p => p.Id.Equals(dto.Id));
//        if (product is null)
//            return new Response<ProductResultDto>
//            {
//                StatusCode = 404,
//                Message = $"This product is not found with Id={dto.Id}",
//            };

//        product.Id = dto.Id;
//        product.Price = dto.Price;
//        product.Unit = dto.Unit;
//        product.Name = dto.Name;
//        product.Quantity = dto.Quantity;
//        product.Description = dto.Description;
//        product.CategoryId = dto.CategoryId;
//        product.UpdatedAt = DateTime.UtcNow;

//        var updatedProduct = (appDbContext.Products.Update(product)).Entity;
//        await appDbContext.SaveChangesAsync();

//        var result = new ProductResultDto
//        {
//            Id = updatedProduct.Id,
//            Unit = updatedProduct.Unit,
//            Name = updatedProduct.Name,
//            Price = updatedProduct.Price,
//            Quantity = updatedProduct.Quantity,
//            Description = updatedProduct.Description,
//        };

//        return new Response<ProductResultDto>
//        {
//            StatusCode = 200,
//            Message = "Success",
//            Data = result
//        };
//    }

//    public async Task<Response<bool>> DeleteAsync(long id)
//    {
//        var product = await appDbContext.Products
//            .FirstOrDefaultAsync(p => p.Id.Equals(id));
//        if (product is null)
//            return new Response<bool>
//            {
//                StatusCode = 404,
//                Message = $"This product is not found with Id={id}",
//                Data = false
//            };

//        appDbContext.Products.Remove(product);
//        await appDbContext.SaveChangesAsync();

//        return new Response<bool>
//        {
//            StatusCode = 200,
//            Message = "Success",
//            Data = true
//        };
//    }

//    public async Task<Response<ProductResultDto>> GetByIdAsync(long id)
//    {
//        var product = await appDbContext.Products
//            .FirstOrDefaultAsync(p => p.Id.Equals(id));
//        if (product is null)
//            return new Response<ProductResultDto>
//            {
//                StatusCode = 404,
//                Message = $"This product is not found with Id={id}",
//            };

//        var result = new ProductResultDto
//        {
//            Description = product.Description,
//            Id = id,
//            Name = product.Name,
//            Price = product.Price,
//            Quantity = product.Quantity,
//            Unit = product.Unit,
//        };

//        return new Response<ProductResultDto>
//        {
//            StatusCode = 200,
//            Message = "Success",
//            Data = result
//        };
//    }

//    public async Task<Response<IEnumerable<ProductResultDto>>> GetAllAsync()
//    {
//        var products = appDbContext.Products.AsEnumerable();

//        var result = new List<ProductResultDto>();
//        foreach (var item in products)
//        {
//            var product = await GetByIdAsync(item.Id);
//            result.Add(product.Data);
//        }

//        return new Response<IEnumerable<ProductResultDto>>
//        {
//            StatusCode = 200,
//            Message = "Success",
//            Data = result
//        };
//    }

//    public async Task<Response<ProductResultDto>> IncreaseQuantity(long productId, double quantity)
//    {
//        var product = await appDbContext.Products
//            .FirstOrDefaultAsync(p => p.Id.Equals(productId));
//        if (product is null)
//            return new Response<ProductResultDto>
//            {
//                StatusCode = 404,
//                Message = $"This product is not found with Id={productId}",
//            };

//        product.Quantity += quantity;
//        product.UpdatedAt = DateTime.UtcNow;

//        var updatedProduct = (appDbContext.Products.Update(product)).Entity;
//        await appDbContext.SaveChangesAsync();

//        var result = new ProductResultDto
//        {
//            Id = updatedProduct.Id,
//            Unit = updatedProduct.Unit,
//            Name = updatedProduct.Name,
//            Price = updatedProduct.Price,
//            Quantity = updatedProduct.Quantity,
//            Description = updatedProduct.Description,
//        };

//        return new Response<ProductResultDto>
//        {
//            StatusCode = 200,
//            Message = "Success",
//            Data = result
//        };
//    }
//}
