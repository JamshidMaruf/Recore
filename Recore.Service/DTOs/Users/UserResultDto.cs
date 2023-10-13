using Recore.Domain.Enums;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Recore.Service.DTOs.Users;

public class UserResultDto
{
    public long Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public UserRole Role { get; set; }
    public DateTime DateOfBirth { get; set; }
    public Gender Gender { get; set; }
    public int OrderCount { get; set; }
}