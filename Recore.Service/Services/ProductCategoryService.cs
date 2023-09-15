using AutoMapper;
using Recore.Service.Exceptions;
using Recore.Service.Interfaces;
using Recore.Data.IRepositories;
using Microsoft.EntityFrameworkCore;
using Recore.Domain.Entities.Products;
using Recore.Service.DTOs.ProductCategories;

namespace Recore.Service.Services;

public class ProductCategoryService : IProductCategoryService
{
    private readonly IMapper mapper;
    private readonly IRepository<ProductCategory> repository;
    public ProductCategoryService(IRepository<ProductCategory> repository, IMapper mapper)
    {
        this.repository = repository;
        this.mapper = mapper;
    }

    public async ValueTask<ProductCategoryResultDto> AddAsync(ProductCategoryCreationDto dto)
    {
        var category = await this.repository.SelectAsync(c => c.Name.Equals(dto.Name));
        if (category is not null)
            throw new AlreadyExistException("This category is already exists");

        var mappedCategory = this.mapper.Map<ProductCategory>(dto);
        await this.repository.CreateAsync(mappedCategory);
        await this.repository.SaveAsync();

        return this.mapper.Map<ProductCategoryResultDto>(mappedCategory);
    }

    public async ValueTask<ProductCategoryResultDto> ModifyAsync(ProductCategoryUpdateDto dto)
    {
        var category = await this.repository.SelectAsync(c => c.Id.Equals(dto.Id), includes: new[] {"Products"} )
            ?? throw new NotFoundException("This category is not found");

        var mappedCategory = this.mapper.Map(dto, category);
        this.repository.Update(mappedCategory);
        await this.repository.SaveAsync();

        return this.mapper.Map<ProductCategoryResultDto>(mappedCategory);
    }

    public async ValueTask<bool> RemoveAsync(long id)
    {
        var category = await this.repository.SelectAsync(c => c.Id.Equals(id))
            ?? throw new NotFoundException("This category is not found");

        this.repository.Delete(category);
        await this.repository.SaveAsync();
        return true;
    }
 
    public async ValueTask<ProductCategoryResultDto> RetrieveByIdAsync(long id)
    {
        var category = await this.repository.SelectAsync(c => c.Id.Equals(id), includes: new[] { "Products" })
            ?? throw new NotFoundException("This category is not found");

        return this.mapper.Map<ProductCategoryResultDto>(category);
    }

    public async ValueTask<IEnumerable<ProductCategoryResultDto>> RetrieveAllAsync()
    {
        var categories = await this.repository.SelectAll(includes: new[] { "Products" }).ToListAsync();
        return this.mapper.Map<IEnumerable<ProductCategoryResultDto>>(categories);
    }
}
