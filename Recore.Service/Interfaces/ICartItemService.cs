using Recore.Service.DTOs.Carts;
using Recore.Domain.Configurations;

namespace Recore.Service.Interfaces;

public interface ICartItemService
{
	ValueTask<IEnumerable<CartItemResultDto>> AddAsync(CartItemCreationDto dto);
	ValueTask<CartItemResultDto> ModifyAsync(CartItemUpdateDto dto);
	ValueTask<bool> RemoveAsync(long id);
	ValueTask<bool> RemoveAllAsync(long cartId);
	ValueTask<CartItemResultDto> RetrieveByIdAsync(long id);
	IEnumerable<CartItemResultDto> RetrieveAll(Filter filter = null, long? cartId = null);
}