using AutoMapper;
using System.Text;
using Recore.Service.Helpers;
using System.Security.Claims;
using Recore.Service.Exceptions;
using Recore.Service.Interfaces;
using Recore.Data.IRepositories;
using Recore.Service.DTOs.Users;
using Recore.Domain.Entities.Users;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.Extensions.Configuration;

namespace Recore.Service.Services;

public class AuthService : IAuthService
{
	private readonly IMapper mapper;
	private readonly IConfiguration configuration;
    private readonly IRepository<User > userRepository;
    public AuthService(IRepository<User> userRepository, IConfiguration configuration, IMapper mapper)
    {
        this.configuration = configuration;
        this.userRepository = userRepository;
        this.mapper = mapper;
    }

    public async ValueTask<string> GenerateTokenAsync(string phone, string originalPassword)
	{
		var user = await this.userRepository.SelectAsync(u => u.Phone.Equals(phone));
		if (user is null)
			throw new NotFoundException("This user is not found");

		bool verifiedPassword = PasswordHash.Verify(user.Password, originalPassword);
		if (!verifiedPassword)
			throw new CustomException(400, "Phone or password is invalid");

		var tokenHandler = new JwtSecurityTokenHandler();
		var tokenKey = Encoding.UTF8.GetBytes(configuration["JWT:Key"]);
		var tokenDescriptor = new SecurityTokenDescriptor
		{
			Subject = new ClaimsIdentity(new Claim[]
			{
				 new Claim("Phone", user.Phone),
				 new Claim("Id", user.Id.ToString()),
				 new Claim(ClaimTypes.Role, user.Role.ToString())
		    }),
			Expires = DateTime.UtcNow.AddHours(1),
			SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256Signature)
		};
		var token = tokenHandler.CreateToken(tokenDescriptor);
		var userResult = this.mapper.Map<UserResultDto>(user);
		
		return tokenHandler.WriteToken(token);
	}
}
