using AutoMapper;
using Recore.Data.IRepositories;
using Recore.Service.Exceptions;
using Recore.Service.Extensions;
using Recore.Service.Interfaces;
using Recore.Domain.Configurations;
using Recore.Service.DTOs.Products;
using Microsoft.EntityFrameworkCore;
using Recore.Domain.Entities.Products;
using Recore.Service.DTOs.Attachments;

namespace Recore.Service.Services;

public class ProductService : IProductService
{
    private readonly IMapper mapper;
    private readonly IAttachmentService attachmentService;
    private readonly IRepository<Product> productRepository;
    private readonly IRepository<ProductCategory> productCategoryRepository;
    public ProductService(
        IMapper mapper,
        IAttachmentService attachmentService,
        IRepository<Product> productRepository,
        IRepository<ProductCategory> productCategoryRepository)
    {
        this.mapper = mapper;
        this.productRepository = productRepository;
        this.attachmentService = attachmentService;
        this.productCategoryRepository = productCategoryRepository;
    }

    public async Task<ProductResultDto> AddAsync(ProductCreationDto dto)
    {
        var product = await this.productRepository.SelectAsync(p => p.Name.Equals(dto.Name), includes: new[] { "Attachment" });
        if (product is not null)
            throw new AlreadyExistException($"This {product.Name.ToLower()} is alread exists");

        var category = await this.productCategoryRepository.SelectAsync(p => p.Id.Equals(dto.CategoryId))
            ?? throw new NotFoundException("This category is not found");

        var mappedProduct = this.mapper.Map<Product>(dto);
        mappedProduct.CategoryId = category.Id;
        mappedProduct.Category = category;
        await this.productRepository.CreateAsync(mappedProduct);
        await this.productRepository.SaveAsync();

        return this.mapper.Map<ProductResultDto>(mappedProduct);
    }

    public async Task<ProductResultDto> IncreaseQuantityAsync(long productId, double quantity)
    {
        var product = await this.productRepository.SelectAsync(p => p.Id.Equals(productId), 
            includes: new[] { "Category", "Attachment" })
            ?? throw new NotFoundException("This product is not found");

        product.Quantity += quantity;
        product.UpdatedAt = DateTime.UtcNow;
        await this.productRepository.SaveAsync();

        return this.mapper.Map<ProductResultDto>(product);
    }

    public async Task<ProductResultDto> ModifyAsync(ProductUpdateDto dto)
    {
        var product = await this.productRepository.SelectAsync(p => p.Id.Equals(dto.Id), includes: new[] { "Attachment" })
            ?? throw new NotFoundException("This product is not found");

        var category = await this.productCategoryRepository.SelectAsync(p => p.Id.Equals(dto.CategoryId))
            ?? throw new NotFoundException("This category is not found");
        
        product.CategoryId = category.Id;
        product.Category = category;
        this.mapper.Map(dto, product);
        this.productRepository.Update(product);
        await this.productRepository.SaveAsync();

        return this.mapper.Map<ProductResultDto>(product);
    }

    public async Task<bool> RemoveAsync(long id)
    {
        var product = await this.productRepository.SelectAsync(p => p.Id.Equals(id))
            ?? throw new NotFoundException("This product is not found");

        this.productRepository.Delete(product);
        await this.productRepository.SaveAsync();
        return true;
    }

    public async Task<IEnumerable<ProductResultDto>> RetrieveAllAsync(PaginationParams @params)
    {
        var products = await this.productRepository.SelectAll(includes: new[] { "Category", "Attachment" })
            .ToPaginate(@params)
            .ToListAsync();

        return this.mapper.Map<IEnumerable<ProductResultDto>>(products);
    }

    public async Task<ProductResultDto> RetrieveByIdAsync(long id)
    {
        var product = await this.productRepository.SelectAsync(p => p.Id.Equals(id), 
            includes: new[] { "Category", "Attachment" })
            ?? throw new NotFoundException("This product is not found");

        return this.mapper.Map<ProductResultDto>(product);
    }

    public async Task<ProductResultDto> ImageUploadAsync(long productId, AttachmentCreationDto dto)
    {
        var product = await this.productRepository.SelectAsync(p => p.Id.Equals(productId), includes: new[] { "Category" })
            ?? throw new NotFoundException("This product is not found");

        var createdAttachment = await this.attachmentService.UploadAsync(dto);
        product.AttachmentId = createdAttachment.Id;
        product.Attachment = createdAttachment;

        this.productRepository.Update(product);
        await this.productRepository.SaveAsync();

        return this.mapper.Map<ProductResultDto>(product);
    }

    public async Task<ProductResultDto> ModifyImageAsync(long productId, AttachmentCreationDto dto)
    {
        var product = await this.productRepository.SelectAsync(p => p.Id.Equals(productId), 
            includes: new[] { "Category", "Attachment" })
            ?? throw new NotFoundException("This product is not found");

        await this.attachmentService.RemoveAsync(product.Attachment);
        var createdAttachment = await this.attachmentService.UploadAsync(dto);

        product.AttachmentId = createdAttachment.Id;
        product.Attachment = createdAttachment;
        this.productRepository.Update(product);
        await this.productRepository.SaveAsync();

        return this.mapper.Map<ProductResultDto>(product);
    }
}
