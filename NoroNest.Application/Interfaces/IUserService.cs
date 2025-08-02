using Microsoft.AspNetCore.Identity;
using NoroNest.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoroNest.Application.Interfaces
{
	public interface IUserService : IBaseService<UserDTO>
	{
		/// <summary>
		/// Registers a new user with the provided UserDTO.
		/// </summary>
		/// <param name="dto">The UserDTO containing user registration details.</param>
		/// <returns>An IdentityResult indicating the success or failure of the registration.</returns>
		Task<IdentityResult> Register(UserDTO dto);
		Task<string> Login(UserDTO dto);
	}
}
