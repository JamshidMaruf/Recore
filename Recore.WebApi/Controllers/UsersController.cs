using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Recore.Domain.Configurations;
using Recore.Domain.Enums;
using Recore.Service.DTOs.Users;
using Recore.Service.Helpers;
using Recore.Service.Interfaces;
using Recore.WebApi.Models;

namespace Recore.WebApi.Controllers;

public class UsersController : BaseController
{
    private readonly IUserService userService;
    private readonly IEmailService emailService;
    public UsersController(IUserService userService, IEmailService emailService)
    {
        this.userService = userService;
        this.emailService = emailService;
    }

    [HttpPost("create")]
    public async ValueTask<IActionResult> PostAsync(UserCreationDto dto)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await this.userService.AddAsync(dto)
        });


    [HttpPut("update")]
    public async ValueTask<IActionResult> PutAsync(UserUpdateDto dto)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await this.userService.ModifyAsync(dto)
        });


    [HttpDelete("delete/{id:long}")]
    public async ValueTask<IActionResult> DeleteAsync(long id)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await this.userService.RemoveAsync(id)
        });


    [HttpGet("get/{id:long}")]
    public async ValueTask<IActionResult> GetByIdAsync(long id)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await this.userService.RetrieveByIdAsync(id)
        });


    [HttpGet("get-all")]
    public async ValueTask<IActionResult> GetAllAsync([FromQuery] PaginationParams @params,[FromQuery]string search)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await this.userService.RetrieveAllAsync(@params,search)
        });


	[HttpPatch("upgrade-role")]
	public async ValueTask<IActionResult> UpgradeRoleAsync(long id, UserRole role)
		=> Ok(new Response
		{
			StatusCode = 200,
			Message = "Success",
			Data = await this.userService.UpgradeRoleAsync(id, role)
		});

    [HttpPost("SendEmail")]
    public async ValueTask<IActionResult> SendEmailAsync(string email)
    {
        MailRequest mailRequest = new MailRequest();
        mailRequest.ToEmail = email;
        mailRequest.Subject = $"Welcome To Recore {email}";
        mailRequest.Body = "Thanks for subscribing us";
        
        await emailService.SendEmailAsync(mailRequest);
        return Ok();
    }
}