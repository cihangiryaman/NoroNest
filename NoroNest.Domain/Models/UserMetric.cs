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
	/// Kullanıcı metrikleri (engagement, churn, etc.)
	/// </summary>
	[Table("UserMetrics")]
	public class UserMetric
	{
		[Key]
		public int Id { get; set; }

		[Required]
		public string UserId { get; set; }

		[ForeignKey("UserId")]
		public virtual User User { get; set; }

		[Required]
		[MaxLength(100)]
		public string MetricType { get; set; } // EngagementScore, ChurnRisk, WeeklyPlayTime, etc.

		public decimal MetricValue { get; set; }

		public DateTime MeasuredAt { get; set; } = DateTime.UtcNow;

		[MaxLength(50)]
		public string TimeFrame { get; set; } // Daily, Weekly, Monthly

		[MaxLength(1000)]
		public string AdditionalData { get; set; } // JSON for extra context
	}
}
