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
using Recore.Domain.Entities.Orders;

namespace Recore.Service.Services;

public class ProductService : IProductService
{
    private readonly IMapper mapper;
    private readonly IAttachmentService attachmentService;
    private readonly IRepository<Product> productRepository;
    private readonly IRepository<OrderItem> orderItemRepository;
    private readonly IRepository<ProductCategory> productCategoryRepository;
    public ProductService(
        IMapper mapper,
        IAttachmentService attachmentService,
        IRepository<Product> productRepository,
        IRepository<ProductCategory> productCategoryRepository,
        IRepository<OrderItem> orderItemRepository)
    {
        this.mapper = mapper;
        this.productRepository = productRepository;
        this.attachmentService = attachmentService;
        this.productCategoryRepository = productCategoryRepository;
        this.orderItemRepository = orderItemRepository;
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
        await this.productRepository.CreateAsync(mappedProduct);
        await this.productRepository.SaveAsync();
        mappedProduct.Category = category;

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

    public async Task<IEnumerable<ProductResultDto>> RetrieveAllAsync()
    {
        var products = await this.productRepository.SelectAll(includes: new[] { "Category", "Attachment" })
            .ToListAsync();

        return this.mapper.Map<IEnumerable<ProductResultDto>>(products);
    }

    public async Task<IEnumerable<ProductResultDto>> RetrieveAllAsync(long categoryId)
    {
        var products = await this.productRepository.SelectAll(expression: p => p.CategoryId == categoryId,
            includes: new[] { "Category", "Attachment" }).ToListAsync();

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

    public async Task<ProductResultDto> DefineSaleCountAsync(long productId)
    {
        var products = this.orderItemRepository.SelectAll(p => p.ProductId.Equals(productId));
        //var productQuantity = products.Select(p => p.Quantity).Sum();
        var product = await this.productRepository.SelectAsync(p => p.Id.Equals(productId));

        return new ProductResultDto
        {
            Id = product.Id,
            Quantity = product.Quantity,
            Description = product.Description,
            Name = product.Name,
            Price = product.Price,
            //SaleCount = (int)productQuantity,
        };
    }

    public async Task<ProductResultDto> SetTopCountAsync(long productId, int saleCount)
    {
        var product = await this.productRepository.SelectAsync(p => p.Id.Equals(productId));
        var productSaleCount = (await DefineSaleCountAsync(productId)).SaleCount;
        if (saleCount <= productSaleCount)
            product.IsTop = true;

        this.productRepository.Update(product);
        await this.productRepository.SaveAsync();

        return this.mapper.Map<ProductResultDto>(product);
    }

    public async Task<ProductResultDto> SetDiscountAsync(long productId, int discount)
    {
        var product = await this.productRepository.SelectAsync(p => p.Id.Equals(productId));
        product.Discount = discount;
        this.productRepository.Update(product);
        await this.productRepository.SaveAsync();
        return this.mapper.Map<ProductResultDto>(product);
    }
}
