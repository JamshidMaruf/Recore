using Recore.Service.Helpers;

namespace Recore.Service.DTOs.Users;

public class UserUpdateDto
{
    public long Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    [CheckEmail]
    public string Email { get; set; }
    [CheckPhone]
    public string Phone { get; set; }
	public string Password { get; set; }
	public DateTime DateOfBirth { get; set; }
}