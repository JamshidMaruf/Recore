using AutoMapper;
using Recore.Domain.Enums;
using Recore.Service.Helpers;
using Recore.Service.Interfaces;
using Recore.Data.IRepositories;
using Recore.Service.DTOs.Orders;
using Microsoft.EntityFrameworkCore;
using Recore.Domain.Entities.Orders;
using Recore.Domain.Entities.Bonuses;
using Recore.Domain.Entities.Settings;
using Recore.Domain.Entities.Warehouses;

namespace Recore.Service.Services;

public class CheckoutService : ICheckoutService
{
	private readonly IMapper mapper;
	private readonly ICartService cartService;
	private readonly IOrderService orderService;
	private readonly IAddressService addressService;
	private readonly ICartItemService cartItemService;
	private readonly IRepository<Bonus> bonusRepository;
	private readonly IRepository<OrderItem> orderItemRepository;
	private readonly IRepository<Warehouse> warehouseRepository;
	private readonly IRepository<BonusSetting> banusSettingRepository;
	public CheckoutService(
		IMapper mapper,
		ICartService cartService,
		IOrderService orderService,
		IAddressService addressService,
		ICartItemService cartItemService,
		IRepository<Bonus> bonusRepository,
		IRepository<OrderItem> orderItemRepository,
		IRepository<Warehouse> warehouseRepository,
		IRepository<BonusSetting> banusSettingRepository)
	{
		this.mapper = mapper;
		this.cartService = cartService;
		this.orderService = orderService;
		this.addressService = addressService;
		this.cartItemService = cartItemService;
		this.bonusRepository = bonusRepository;
		this.orderItemRepository = orderItemRepository;
		this.warehouseRepository = warehouseRepository;
		this.banusSettingRepository = banusSettingRepository;
	}

	public async ValueTask<OrderResultDto> SetOrderAsync(MainOrderDto dto)
	{
		var cart = await this.cartService.RetrieveByUserIdAsync(HttpContextHelper.GetUserId);
		var cartItems = this.cartItemService.RetrieveAll(cartId: cart.Id);

		//TODO: Subtract products from Warehouse (inventory)

		//TODO: Create payment
		//TODO: Get order setting
		var address = await this.addressService.AddAsync(dto.Address);

		var order = new OrderCreationDto
		{
			AddressId = address.Id,
			Status = Status.Pending,
			StartAt = DateTime.UtcNow,
			UserId = HttpContextHelper.GetUserId,

			//TODO: Add payment from getting payment object
			//TODO: Add DeliveryFee via order setting
			//TODO: Add EndTime via order setting
		};
		var createdOrder = await this.orderService.AddAsync(order);
		var orderItems = new List<OrderItem>();
        foreach (var item in cartItems)
        {
			var orderItem = new OrderItem
			{
				Summ = item.Summ,
				Price = item.Price,
				CartItemId = item.Id,
				Quantity = item.Quantity,
				OrderId = createdOrder.Id,
				ProductId = item.Product.Id
			};
			await this.orderItemRepository.CreateAsync(orderItem);
			orderItems.Add(orderItem);
        }
		await this.orderItemRepository.SaveAsync();

		var checkBonus = await CheckBonusAsync(createdOrder, orderItems);

		return this.mapper.Map<OrderResultDto>(order);
    }

	private async Task<OrderResultDto> CheckBonusAsync(OrderResultDto order, List<OrderItem> orderItems)
	{
		var bonusSettings = banusSettingRepository.SelectAll();
		var priceOfOrder = orderItems.Sum(orderItem => orderItem.Summ);

		var lastBonus = await bonusRepository.SelectAll()
			.OrderByDescending(bonus => bonus.Id)
			.FirstOrDefaultAsync();
		if (lastBonus is null)
			lastBonus = new Bonus();

		var bonus = new Bonus();
        foreach (var item in bonusSettings)
        {
            if(priceOfOrder >= item.From && priceOfOrder < item.To)
			{
				if (item.IsWeekDay)
				{
					var thisDay = (int)DateTime.UtcNow.DayOfWeek;
					if((int)item.Weekday == thisDay)
					{
						if(order.CreatedAt > item.StartTime && order.CreatedAt < item.EndTime)
						{
							switch (item.Type)
							{
								case BonusSettingType.Amount:
									bonus.OrderId = order.Id;
									bonus.BonusSettingId = item.Id;
									bonus.UserId = HttpContextHelper.GetUserId;
									bonus.Amount = lastBonus.Amount + item.Amount;
									break;
								case BonusSettingType.Percentage:
									bonus.OrderId = order.Id;
									bonus.BonusSettingId = item.Id;
									bonus.UserId = HttpContextHelper.GetUserId;
									bonus.Amount = lastBonus.Amount + ((priceOfOrder / 100) * item.Amount);
									break;
								case BonusSettingType.Gift:
									break;
								default: 
									break;
							}
						}
					}
				}

				if (item.IsDate)
				{
					if(order.CreatedAt > item.StartTime && order.CreatedAt < item.EndTime)
					{
						switch (item.Type)
						{
							case BonusSettingType.Amount:
								bonus.OrderId = order.Id;
								bonus.BonusSettingId = item.Id;
								bonus.UserId = HttpContextHelper.GetUserId;
								bonus.Amount = lastBonus.Amount + item.Amount;
								break;
							case BonusSettingType.Percentage:
								bonus.OrderId = order.Id;
								bonus.BonusSettingId = item.Id;
								bonus.UserId = HttpContextHelper.GetUserId;
								bonus.Amount = lastBonus.Amount + ((priceOfOrder / 100) * item.Amount);
								break;
							case BonusSettingType.Gift:
								break;
							default:
								break;
						}
					}
				}
			}
        }
		throw new NotImplementedException();
    }

	private async Task<OrderResultDto> CheckPromoCodeAsync(string promoCode, OrderResultDto order, List<OrderItem> orderItems)
	{
		var bonusSettings = banusSettingRepository.SelectAll();
		var priceOfOrder = orderItems.Sum(orderItem => orderItem.Summ);

		if (!string.IsNullOrEmpty(promoCode))
		{
			foreach (var item in bonusSettings)
			{
				if (priceOfOrder >= item.From && priceOfOrder < item.To)
				{
					if (item.IsDate)
					{
						if (order.CreatedAt > item.StartTime && order.CreatedAt < item.EndTime)
						{

						}
					}
				}
			}
		}

		throw new NotImplementedException();
	}
}
