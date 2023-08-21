//using Microsoft.EntityFrameworkCore;
//using Recore.Data.Contexts;
//using Recore.Service.DTOs.ProductCategories;
//using Recore.Service.DTOs.Products;
//using Recore.Service.Helpers;
//using Recore.Service.Interfaces;

//namespace Recore.Service.Services;

//public class ProductCategoryService : IProductCategoryService
//{
//    private readonly AppDbContext appDbContext = new AppDbContext();

//    public Task<Response<ProductCategoryResultDto>> CreateAsync(ProductCategoryCreationDto dto)
//    {
//        throw new NotImplementedException();
//    }

//    public Task<Response<bool>> DeleteAsync(long id)
//    {
//        throw new NotImplementedException();
//    }

//    public Task<Response<IEnumerable<ProductCategoryResultDto>>> GetAllAsync()
//    {
//        throw new NotImplementedException();
//    }

//    public async Task<Response<ProductCategoryResultDto>> GetByIdAsync(long id)
//    {
//        var category = await appDbContext.ProductCategories
//            .FirstOrDefaultAsync(c => c.Id == id);
//        if (category is null)
//            return new Response<ProductCategoryResultDto>
//            {
//                StatusCode = 404,
//                Message = $"This category is not found with id={id}"
//            };

//        var result = new ProductCategoryResultDto
//        {
//            Id = id,
//            Name = category.Name
//        };

//        return new Response<ProductCategoryResultDto>
//        {
//            StatusCode = 200,
//            Message = "Success",
//            Data = result
//        };
//    }

//    public Task<Response<ProductCategoryResultDto>> UpdateAsync(ProductCategoryUpdateDto dto)
//    {
//        throw new NotImplementedException();
//    }
//}
