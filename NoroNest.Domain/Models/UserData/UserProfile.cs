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
	///		Kullanıcı profil ve kişiselleştirme bilgileri
	/// </summary>
	[Table("UserProfiles")]
	public class UserProfile
	{
		[Key]
		public int Id { get; set; }

		[Required]
		public string UserId { get; set; }

		[ForeignKey("UserId")]
		public virtual User User { get; set; }

		// Alzheimer seviyesi ve durumu
		[MaxLength(50)]
		public string AlzheimerStage { get; set; } // Early, Moderate, Severe

		public DateTime? DiagnosisDate { get; set; }

		// Kişiselleştirme parametreleri
		public int DifficultyLevel { get; set; } = 1; // 1-10 arası
		public int PreferredSessionDuration { get; set; } = 15; // dakika

		[MaxLength(500)]
		public string PreferredGameTypes { get; set; } // JSON array olarak

		[MaxLength(500)]
		public string CognitiveStrengths { get; set; } // JSON array

		[MaxLength(500)]
		public string CognitiveWeaknesses { get; set; } // JSON array

		public decimal EngagementScore { get; set; } = 0;

		public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
		public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

		// Navigation Properties
		public virtual ICollection<PersonalizationSetting> PersonalizationSettings { get; set; }
	}
}
