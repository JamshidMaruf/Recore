using AutoMapper;
using Recore.Data.IRepositories;
using Recore.Service.DTOs.Carts;
using Recore.Service.Interfaces;
using Recore.Domain.Entities.Carts;

namespace Recore.Service.Services;

public class CartService : ICartService
{
	private readonly IMapper mapper;
	private readonly IRepository<Cart> repository;
	public CartService(IMapper mapper, IRepository<Cart> repository)
	{
		this.mapper = mapper;
		this.repository = repository;
	}

	public async ValueTask<CartResultDto> RetrieveByUserIdAsync(long userId)
	{
		var cart = await this.repository.SelectAsync(cart => cart.UserId.Equals(userId));
		return this.mapper.Map<CartResultDto>(cart);
	}
}
