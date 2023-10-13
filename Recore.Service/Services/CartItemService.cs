using AutoMapper;
using Recore.Service.Helpers;
using Recore.Data.IRepositories;
using Recore.Service.Interfaces;
using Recore.Service.DTOs.Carts;
using Recore.Service.Exceptions;
using Recore.Domain.Entities.Carts;
using Recore.Domain.Configurations;
using Recore.Domain.Entities.Inventories;
using Recore.Service.Extensions;

namespace Recore.Service.Services;

public class CartItemService : ICartItemService
{
	private readonly IMapper mapper;
	private readonly IRepository<Cart> cartRepository;
	private readonly IRepository<Inventory> inventoryRepository;
    private readonly IRepository<CartItem> cartItemRepository;
    public CartItemService(IMapper mapper, IRepository<CartItem> repository, IRepository<Cart> cartRepository, IRepository<Inventory> inventoryRepository)
    {
        this.mapper = mapper;
        this.cartItemRepository = repository;
        this.cartRepository = cartRepository;
        this.inventoryRepository = inventoryRepository;
    }

    public async ValueTask<IEnumerable<CartItemResultDto>> AddAsync(CartItemCreationDto dto)
	{
		if (HttpContextHelper.GetUserId != 0)
			throw new CustomException(401, "This user is not authorized");

		var cart = await this.cartRepository.SelectAsync(cart => cart.UserId.Equals(HttpContextHelper.GetUserId));

		var result = new List<CartItemResultDto>();
		foreach (var item in dto.Details)
		{
			var inventory = await this.inventoryRepository.SelectAsync(inventory => inventory.ProductId.Equals(item.ProductId));
			var cartItem = new CartItem
			{
				CartId = cart.Id,
				Price = inventory.Price,
				ProductId = item.ProductId,
				Quantity = item.Quantity,
				Summ = (decimal)item.Quantity * inventory.Price
			};
			await this.cartItemRepository.CreateAsync(cartItem);
			result.Add(this.mapper.Map<CartItemResultDto>(cartItem));
        }
		await this.cartItemRepository.SaveAsync();

		return result;
    }

	public async ValueTask<CartItemResultDto> ModifyAsync(CartItemUpdateDto dto)
	{
		var cartItem = await this.cartItemRepository.SelectAsync(cartItem => cartItem.Id.Equals(dto.Id))
			?? throw new NotFoundException("Cart item is not found");

		var mappedCartItem = this.mapper.Map(dto, cartItem);
		this.cartItemRepository.Update(mappedCartItem);
		await this.cartItemRepository.SaveAsync();

		return this.mapper.Map<CartItemResultDto>(mappedCartItem);
	}

	public async ValueTask<bool> RemoveAllAsync(long cartId)
	{
		var cartItems = this.cartItemRepository.SelectAll(cartItem => cartItem.CartId.Equals(cartId));
		foreach (var cartItem in cartItems)
            this.cartItemRepository.Destroy(cartItem);

        await this.cartItemRepository.SaveAsync();
		return true;
    }

	public async ValueTask<bool> RemoveAsync(long id)
	{
        var cartItem = await this.cartItemRepository.SelectAsync(cartItem => cartItem.Id.Equals(id))
            ?? throw new NotFoundException("Cart item is not found");

		this.cartItemRepository.Destroy(cartItem);
		await this.cartItemRepository.SaveAsync();
		return true;
    }

	public IEnumerable<CartItemResultDto> RetrieveAll(Filter filter = null, long? cartId = null)
	{
		var carts = this.cartItemRepository.SelectAll(includes: new[] { "Product" }).OrderBy(filter);

		if(cartId is not null)
			carts = carts.Where(cartItem => cartItem.CartId.Equals(cartId));

		return this.mapper.Map<IEnumerable<CartItemResultDto>>(carts);
	}

	public async ValueTask<CartItemResultDto> RetrieveByIdAsync(long id)
	{
		var cartItem = 
			await this.cartItemRepository.SelectAsync(cartItem => cartItem.Id.Equals(id), includes: new[] { "Product" });
		
		if(cartItem is null)
			throw new NotFoundException("This cart item is not found");

		return this.mapper.Map<CartItemResultDto>(cartItem);
	}
}