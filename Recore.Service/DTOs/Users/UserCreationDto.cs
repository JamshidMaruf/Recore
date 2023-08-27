using Recore.Domain.Enums;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Recore.Service.DTOs.Users;

public class UserCreationDto
{
    [DisplayName("Firstname")]
    public string FirstName { get; set; }

    [DisplayName("Lastname")]
    public string LastName { get; set; }

    [DisplayName("Email")]
    public string Email { get; set; }
    
    [DisplayName("Password")]
    public string Password { get; set; }

    [DisplayName("Phone")]
    public string Phone { get; set; }

    [DisplayName("Date of birth")]
    public DateTime DateOfBirth { get; set; }
}