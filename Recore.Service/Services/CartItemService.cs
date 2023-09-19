using AutoMapper;
using Recore.Service.Helpers;
using Recore.Data.IRepositories;
using Recore.Service.Interfaces;
using Recore.Service.DTOs.Carts;
using Recore.Service.Exceptions;
using Recore.Domain.Entities.Carts;
using Recore.Domain.Configurations;

namespace Recore.Service.Services;

public class CartItemService : ICartItemService
{
	private readonly IMapper mapper;
	private readonly IRepository<Cart> cartRepository;
	private readonly IRepository<CartItem> cartItemRepository;
	public CartItemService(IMapper mapper, IRepository<CartItem> repository, IRepository<Cart> cartRepository)
	{
		this.mapper = mapper;
		this.cartItemRepository = repository;
		this.cartRepository = cartRepository;
	}

	public async ValueTask<IEnumerable<CartItemResultDto>> AddAsync(CartItemCreationDto dto)
	{
		if (HttpContextHelper.GetUserId != 0)
			throw new CustomException(401, "This user is not authorized");

		var cart = await this.cartRepository.SelectAsync(cart => cart.UserId.Equals(HttpContextHelper.GetUserId));

		var result = new List<CartItemResultDto>();
		foreach (var item in dto.Details)
		{
			var cartItem = new CartItem
			{
				CartId = cart.Id,
				Price = item.Price,
				ProductId = item.ProductId,
				Quantity = item.Quantity,
				Summ = (decimal)item.Quantity * item.Price
			};
			await this.cartItemRepository.CreateAsync(cartItem);
			result.Add(this.mapper.Map<CartItemResultDto>(cartItem));
        }
		await this.cartItemRepository.SaveAsync();

		return result;
    }

	public ValueTask<CartItemResultDto> ModifyAsync(CartItemUpdateDto dto)
	{
		throw new NotImplementedException();
	}

	public ValueTask<bool> RemoveAllAsync(long cartId)
	{
		throw new NotImplementedException();
	}

	public ValueTask<bool> RemoveAsync(long id)
	{
		throw new NotImplementedException();
	}

	public IEnumerable<CartItemResultDto> RetrieveAll(Filter filter = null, long? cartId = null)
	{
		var carts = this.cartItemRepository.SelectAll(includes: new[] { "Product" });

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