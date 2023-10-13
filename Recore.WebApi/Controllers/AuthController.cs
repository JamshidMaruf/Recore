using Recore.WebApi.Models;
using Microsoft.AspNetCore.Mvc;
using Recore.Service.Interfaces;

namespace Recore.WebApi.Controllers;

public class AuthController : BaseController
{
    private readonly IAuthService authService;
	private readonly IUserService userService;
    public AuthController(IAuthService authService, IUserService userService)
    {
        this.authService = authService;
        this.userService = userService;
    }

    [HttpPost("login")]
	public async Task<IActionResult> GenerateTokenAsync(string phone, string password)
	{
		var user = await this.userService.RetrieveByPhoneAsync(phone);
		var token = await this.authService.GenerateTokenAsync(phone, password);

        return Ok(new Response
		{
			StatusCode = 200,
			Message = "Success",
			Data = new UserResponse
			{
				User = user,
				Token = token
			}
		});

	}
}
