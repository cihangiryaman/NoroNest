using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using NoroNest.Application.DTOs;
using NoroNest.Application.Interfaces;
using NoroNest.Domain.Models.Identity;
using NoroNest.Infrastructure.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace NoroNest.Application.Services
{
	public class UserService : BaseService<User, UserDTO>, IUserService
	{
		private readonly UserManager<User> _userManager;
		private readonly IConfiguration _config;

		public UserService(IUnitOfWork unitOfWork, IMapper mapper, UserManager<User> userManager, IConfiguration config, string keyPropertyName = "Id") : base(unitOfWork, mapper, keyPropertyName)
		{
			_userManager = userManager;
			_config = config;
		}

		public async Task<IdentityResult> Register(UserDTO dto)
		{
			User user = _mapper.Map<User>(dto);
			IdentityResult result = await _userManager.CreateAsync(user, dto.Password);
			return result;
		}

		public async Task<string> Login(UserDTO dto)
		{
			var user = await _userManager.FindByNameAsync(dto.UserName);
			if (user == null)
				return String.Empty;

			if (!await _userManager.CheckPasswordAsync(user, dto.Password))
				return String.Empty;

			// Token oluştur
			var token = GenerateJwtToken(dto);
			return token;
		}

		private string GenerateJwtToken(UserDTO dto)
		{
			var jwtSettings = _config.GetSection("Jwt");
			var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings["Key"]));
			var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

			var claims = new[]
			{
				new Claim(JwtRegisteredClaimNames.Sub, dto.UserName),
				new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
				// role veya diğer claim’ler:
				// new Claim(ClaimTypes.Role, "Admin")
			};

			var token = new JwtSecurityToken(
				issuer: jwtSettings["Issuer"],
				audience: jwtSettings["Audience"],
				claims: claims,
				expires: DateTime.UtcNow.AddMinutes(double.Parse(jwtSettings["ExpireMinutes"])),
				signingCredentials: creds
			);

			return new JwtSecurityTokenHandler().WriteToken(token);
		}
	}
}
