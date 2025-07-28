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
	/// Gelişim raporları
	/// </summary>
	[Table("ProgressReports")]
	public class ProgressReport
	{
		[Key]
		public int Id { get; set; }

		[Required]
		public string UserId { get; set; }

		[ForeignKey("UserId")]
		public virtual User User { get; set; }

		[MaxLength(50)]
		public string ReportType { get; set; } // Weekly, Monthly, Custom

		public DateTime StartDate { get; set; }
		public DateTime EndDate { get; set; }

		public int TotalSessionsPlayed { get; set; } = 0;
		public int TotalTimePlayedMinutes { get; set; } = 0;

		public decimal AverageScore { get; set; } = 0;
		public decimal AverageEngagementScore { get; set; } = 0;

		public decimal ImprovementRate { get; set; } = 0; // Yüzde olarak

		[MaxLength(2000)]
		public string CognitiveMetrics { get; set; } // JSON data

		[MaxLength(1000)]
		public string Insights { get; set; }

		[MaxLength(1000)]
		public string Recommendations { get; set; }

		public DateTime GeneratedAt { get; set; } = DateTime.UtcNow;

		// Navigation Properties
		public virtual ICollection<ProgressMetric> ProgressMetrics { get; set; }
	}
}
