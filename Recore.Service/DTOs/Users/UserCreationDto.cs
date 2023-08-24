using Recore.Domain.Enums;

namespace Recore.Service.DTOs.Users;

public class UserCreationDto
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public string Password { get; set; }
    public DateTime DateOfBirth { get; set; }
}