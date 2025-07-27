using NoroNest.Domain.Models.Identity;
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
	/// AI önerileri
	/// </summary>
	public class AIRecommendation
	{
		[Key]
		public int Id { get; set; }

		[Required]
		public string UserId { get; set; }

		[ForeignKey("UserId")]
		public virtual User User { get; set; }

		[MaxLength(100)]
		public string RecommendationType { get; set; } // GameRecommendation, DifficultyAdjustment, SessionTiming

		[MaxLength(1000)]
		public string RecommendationData { get; set; } // JSON data

		public decimal ConfidenceScore { get; set; } = 0;

		public bool IsApplied { get; set; } = false;
		public DateTime? AppliedAt { get; set; }

		public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
		public DateTime ExpiresAt { get; set; }

		[MaxLength(500)]
		public string Reason { get; set; }
	}
}
