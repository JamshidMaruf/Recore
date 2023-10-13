using Recore.Service.DTOs.Users;

namespace Recore.Service.Interfaces;

public interface IAuthService
{
    ValueTask<string> GenerateTokenAsync(string phone, string originalPassword);
}
