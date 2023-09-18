using AutoMapper;
using Recore.Data.IRepositories;
using Recore.Service.Interfaces;
using Recore.Domain.Entities.Carts;
using Recore.Service.DTOs.Carts;
using Recore.Domain.Configurations;
using Microsoft.AspNetCore.Http;
using Recore.Service.Helpers;

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

	public async ValueTask<CartItemResultDto> AddAsync(CartItemCreationDto dto)
	{
		var mappedCartItem = this.mapper.Map<CartItem>(dto);

		// TODO: Get last price from warehouse

		if(HttpContextHelper.GetUserId != 0)
		{
			var existCart = await this.cartRepository
				.SelectAsync(cart => cart.UserId == HttpContextHelper.GetUserId);

			if (existCart is null)
			{
				existCart = new Cart
				{
					UserId = HttpContextHelper.GetUserId,
				};
				await this.cartRepository.CreateAsync(existCart);
				await this.cartRepository.SaveAsync();
			}

            foreach (var item in dto.Details)
            {
				var cartItem = new CartItem
				{
					Price = item.Price,
					CartId = existCart.Id,
					Quantity = item.Quantity,
					ProductId = item.ProductId,
				};
				await this.cartItemRepository.CreateAsync(cartItem);
            }
			await this.cartItemRepository.SaveAsync();
		}

		var cart = new Cart();
		await this.cartRepository.CreateAsync(cart);
		foreach (var item in dto.Details)
		{
			var cartItem = new CartItem
			{
				Price = item.Price,
				CartId = cart.Id,
				Quantity = item.Quantity,
				ProductId = item.ProductId,
			};
			await this.cartItemRepository.CreateAsync(cartItem);
		}
		await this.cartItemRepository.SaveAsync();

		throw new NotImplementedException();
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

	public ValueTask<IEnumerable<CartItemResultDto>> RetrieveAllAsync(Filter filter, long cartId)
	{
		throw new NotImplementedException();
	}

	public ValueTask<CartItemResultDto> RetrieveByIdAsync(long id)
	{
		throw new NotImplementedException();
	}
}