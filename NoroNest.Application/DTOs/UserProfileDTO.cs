using NoroNest.Domain.Models.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoroNest.Application.DTOs
{
	public class UserProfileDTO
	{
		public int Id { get; set; }
		public string UserId { get; set; }
		public string AlzheimerStage { get; set; } // Early, Moderate, Severe
		public DateTime? DiagnosisDate { get; set; }
		public int DifficultyLevel { get; set; } = 1; // 1-10 arası
		public int PreferredSessionDuration { get; set; } = 15; // dakika
		public string PreferredGameTypes { get; set; } // JSON array olarak
		public string CognitiveStrengths { get; set; } // JSON array
		public string CognitiveWeaknesses { get; set; } // JSON array
		public decimal EngagementScore { get; set; } = 0; // 0-100
		public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
		public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

	}
}
