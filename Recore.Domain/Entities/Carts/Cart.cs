using Recore.Domain.Commons;
using Recore.Domain.Entities.Users;
namespace Recore.Domain.Entities.Carts;

public class Cart : Auditable
{
    public decimal TotalPrice { get; set; }
    public long? UserId { get; set; }
    public User User { get; set; }
}
