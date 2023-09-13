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
	private readonly IRepository<CartItem> repository;
	public CartItemService(IMapper mapper, IRepository<CartItem> repository)
	{
		this.mapper = mapper;
		this.repository = repository;
	}

	public ValueTask<CartItemResultDto> AddAsync(CartItemCreationDto dto)
	{
		var mappedCartItem = this.mapper.Map<CartItem>(dto);

		// TODO: Get last price from warehouse

		

		var cart = new Cart
		{
			UserId = HttpContextHelper.GetUserId
		};

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