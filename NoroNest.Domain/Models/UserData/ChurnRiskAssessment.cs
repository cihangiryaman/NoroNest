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
	/// Kullanıcı kayıp riski değerlendirmesi
	/// </summary>
	[Table("ChurnRiskAssessments")]
	public class ChurnRiskAssessment
	{
		[Key]
		public int Id { get; set; }

		[Required]
		public string UserId { get; set; }

		[ForeignKey("UserId")]
		public virtual User User { get; set; }

		public decimal ChurnRiskScore { get; set; } // 0-1 arası

		[MaxLength(50)]
		public string RiskLevel { get; set; } // Low, Medium, High, Critical

		[MaxLength(1000)]
		public string RiskFactors { get; set; } // JSON array

		public int DaysSinceLastSession { get; set; } = 0;
		public decimal EngagementTrend { get; set; } = 0; // Pozitif/negatif trend

		public DateTime AssessedAt { get; set; } = DateTime.UtcNow;
		public DateTime? InterventionDate { get; set; }

		[MaxLength(500)]
		public string RecommendedActions { get; set; } // JSON array
	}
}
