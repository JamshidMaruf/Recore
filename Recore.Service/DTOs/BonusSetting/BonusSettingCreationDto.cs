using Recore.Domain.Enums;

namespace Recore.Service.DTOs.BonusSetting;

public class BonusSettingCreationDto
{
    public string Name { get; set; }
    public string Description { get; set; }
    public BonusSettingType Type { get; set; }
    public string PromoCode { get; set; }
    public decimal Amount { get; set; }
    public decimal From { get; set; }
    public decimal? To { get; set; }
    public int OrderQuantity { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    public Weekday Weekday { get; set; }
}