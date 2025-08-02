using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using NoroNest.Application.DTOs;
using NoroNest.Application.Interfaces;
using NoroNest.Application.Services;
using NoroNest.Domain.Models.Identity;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace NoroNest.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AuthController : ControllerBase
	{
		private readonly IConfiguration _config;
		private readonly IMapper _mapper;
		private readonly IUserService _userService;

		public AuthController(IUserService userService, IConfiguration config, IMapper mapper)
		{
			_userService = userService;
			_config = config;
			_mapper = mapper;
		}

		[HttpPost("register")]
		public async Task<IActionResult> Register(UserDTO dto)
		{
			var result = await _userService.Register(dto);
			if (!result.Succeeded)
				return BadRequest(result.Errors);

			return Ok(new { message = "Kayıt başarılı" });
		}

		[HttpPost("login")]
		public async Task<IActionResult> Login(UserDTO dto)
		{
			var token = await _userService.Login(dto);
			if (token == String.Empty)
				return Unauthorized(new { message = "Kullanıcı adı veya şifre yanlış" });
			return Ok(new { token });
		}
	}
}
