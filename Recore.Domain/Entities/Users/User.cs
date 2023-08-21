using Recore.Domain.Commons;
using Recore.Domain.Enums;

namespace Recore.Domain.Entities.Users;

public class User : Auditable
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public UserRole Role { get; set; }
    public DateTime DateOfBirth { get; set; }
}
