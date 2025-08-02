using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoroNest.Application.DTOs
{
	public class UserDTO
	{
		public Guid Id { get; set; }
		public int IdentificationNumber { get; set; }
		public string FirstName { get; set; }
		public string Lastname { get; set; }
		public string Password { get; set; }
		public string PhoneNumber { get; set; }
		public string Email { get; set; }
		public string UserName { get; set; }
		public DateTime DateOfBirth { get; set; }
		public string Gender { get; set; }
		public bool IsActive { get; set; } = true;
	}
}
