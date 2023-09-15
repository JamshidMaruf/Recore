using Recore.Domain.Configurations;
using Recore.Service.DTOs.Carts;

namespace Recore.Service.Interfaces;

public interface ICartItemService
{
	ValueTask<CartItemResultDto> AddAsync(CartItemCreationDto dto);
	ValueTask<CartItemResultDto> ModifyAsync(CartItemUpdateDto dto);
	ValueTask<bool> RemoveAsync(long id);
	ValueTask<bool> RemoveAllAsync(long cartId);
	ValueTask<CartItemResultDto> RetrieveByIdAsync(long id);
	ValueTask<IEnumerable<CartItemResultDto>> RetrieveAllAsync(Filter filter, long cartId);
}