using NoroNest.Domain.Models.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoroNest.Domain.Models.UserData
{
	/// <summary>
	/// Kullanıcı kazanım maliyeti takibi
	/// </summary>
	[Table("UserAcquisitions")]
	public class UserAcquisition
	{
		[Key]
		public int Id { get; set; }

		[Required]
		public string UserId { get; set; }

		[ForeignKey("UserId")]
		public virtual User User { get; set; }

		[MaxLength(100)]
		public string AcquisitionChannel { get; set; } // Organic, Google Ads, Facebook, etc.

		[MaxLength(200)]
		public string Campaign { get; set; }

		public decimal AcquisitionCost { get; set; } = 0;

		public DateTime AcquisitionDate { get; set; } = DateTime.UtcNow;

		[MaxLength(500)]
		public string ReferralData { get; set; } // JSON data
	}
}
