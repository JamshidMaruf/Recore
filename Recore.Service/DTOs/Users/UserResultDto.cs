using Recore.Domain.Enums;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Recore.Service.DTOs.Users;

public class UserResultDto
{
    [DisplayName("ID")]
    public long Id { get; set; }
    
    [DisplayName("Firstname")]
    public string FirstName { get; set; }
    
    [DisplayName("Lastname")]
    public string LastName { get; set; }

    [DisplayName("Email")]
    public string Email { get; set; }

    [DisplayName("Phone")]
    public string Phone { get; set; }

    [DisplayName("Role")]
    public UserRole Role { get; set; }

    [DisplayName("DateOfBirth")]
    public DateTime DateOfBirth { get; set; }
}
