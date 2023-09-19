using Recore.Domain.Commons;
using Recore.Domain.Entities.Orders;
using Recore.Domain.Entities.Users;

namespace Recore.Domain.Entities.Settings;

public class UserPromoCodeSetting : Auditable
{
	public string PromoCode { get; set; }
	public long UserId { get; set; }
	public User User { get; set; }
	public long OrderId { get; set; }
	public Order Order { get; set; }
	public long BonusSettingId { get; set; }
	public BonusSetting BonusSetting { get; set; }
}
