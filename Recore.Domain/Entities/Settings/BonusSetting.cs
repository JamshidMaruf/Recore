using Recore.Domain.Enums;
using Recore.Domain.Commons;

namespace Recore.Domain.Entities.Settings;

public class BonusSetting : Auditable
{
    /// <summary>
    /// Name of bonus for exaple "White Friday"
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Description for using
    /// </summary>
    public string Description { get; set; }

    /// <summary>
    /// Type of giving bonus
    /// </summary>
    public BonusSettingType Type { get; set; }

    /// <summary>
    /// promocode for order
    /// </summary>
    public string PromoCode { get; set; }

    public int PromoCodeCount { get; set; }

    /// <summary>
    /// Amount for order that if requirments are true 
    /// </summary>
    public decimal Amount { get; set; }

    /// <summary>
    /// Initial amount of order
    /// </summary>
    public decimal From { get; set; }

    /// <summary>
    /// Last amount of order
    /// </summary>
    public decimal? To { get; set; }

    /// <summary>
    /// Number of order that If customer order in some time
    /// </summary>
    public int OrderQuantity { get; set; }

    /// <summary>
    /// Start time for giving bonus
    /// </summary>
    public DateTime StartTime { get; set; }

    /// <summary>
    /// End time for giving bonus
    /// </summary>
    public DateTime EndTime { get; set; }

    /// <summary>
    /// Weekdays
    /// </summary>
    public Weekday Weekday { get; set; } = Weekday.Null;
    public long? ProductId { get; set; }
    public bool IsWeekDay { get; set; }
    public bool IsDate { get; set; }
}
