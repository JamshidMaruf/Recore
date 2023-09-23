using System.ComponentModel;
using Recore.Service.Helpers;

namespace Recore.Service.DTOs.Users;

public class UserCreationDto
{
    [DisplayName("Firstname")]
    public string FirstName { get; set; }

    [DisplayName("Lastname")]
    public string LastName { get; set; }

    [DisplayName("Email"), CheckEmail]
    public string Email { get; set; }
    
    [DisplayName("Password")]
    public string Password { get; set; }

    [DisplayName("Phone"), CheckPhone]
    public string Phone { get; set; }

    [DisplayName("Date of birth")]
    public DateTime DateOfBirth { get; set; }
}