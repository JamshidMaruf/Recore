using Recore.Domain.Commons;
using Recore.Domain.Entities.Users;
using Recore.Domain.Entities.Orders;

namespace Recore.Domain.Entities.Bonuses;

public class Bonus : Auditable
{
    public decimal Amount { get; set; }
    public long BonusSettingId { get; set; }
    public BonusSetting BonusSetting { get; set; }
    public long OrderId { get; set; }
    public Order Order { get; set; }
    public long UserId { get; set; }
    public User User { get; set; }
}
