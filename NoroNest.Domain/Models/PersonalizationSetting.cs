using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoroNest.Domain.Models
{
	/// <summary>
	/// Kişiselleştirme ayarları
	/// </summary>
	[Table("PersonalizationSettings")]
	public class PersonalizationSetting
	{
		[Key]
		public int Id { get; set; }

		[Required]
		public int UserProfileId { get; set; }

		[ForeignKey("UserProfileId")]
		public virtual UserProfile UserProfile { get; set; }

		[Required]
		[MaxLength(100)]
		public string SettingKey { get; set; }

		[MaxLength(1000)]
		public string SettingValue { get; set; }

		[MaxLength(50)]
		public string SettingType { get; set; } // String, Integer, Boolean, JSON

		public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
		public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
	}
}
