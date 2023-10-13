using Recore.Service.DTOs.Users;

namespace Recore.WebApi.Models;

public class UserResponse
{
    public UserResultDto User { get; set; }
    public string Token { get; set; }
}