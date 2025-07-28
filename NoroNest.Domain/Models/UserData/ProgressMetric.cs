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
	/// Gelişim metrikleri
	/// </summary>
	[Table("ProgressMetrics")]
	public class ProgressMetric
	{
		[Key]
		public int Id { get; set; }

		[Required]
		public int ProgressReportId { get; set; }

		[ForeignKey("ProgressReportId")]
		public virtual ProgressReport ProgressReport { get; set; }

		[Required]
		[MaxLength(100)]
		public string MetricName { get; set; }

		public decimal MetricValue { get; set; }

		public decimal PreviousValue { get; set; } = 0;

		public decimal ChangePercentage { get; set; } = 0;

		[MaxLength(50)]
		public string MetricUnit { get; set; } // Score, Minutes, Percentage, etc.

		[MaxLength(500)]
		public string Description { get; set; }
	}
}
