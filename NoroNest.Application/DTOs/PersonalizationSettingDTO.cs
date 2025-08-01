using NoroNest.Domain.Models.UserData;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoroNest.Application.DTOs
{
	public class PersonalizationSettingDTO
	{
		public int Id { get; set; }
		public int UserProfileId { get; set; }
		public string SettingKey { get; set; }
		public string SettingValue { get; set; }
		public string SettingType { get; set; } // String, Integer, Boolean, JSON
		public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
		public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
	}
}
