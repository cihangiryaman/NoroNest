using NoroNest.Domain.Models.Identity;
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
	public class ProgressReportDTO
	{
		public int Id { get; set; }
		public string UserId { get; set; }
		public string ReportType { get; set; } // Weekly, Monthly, Custom

		public DateTime StartDate { get; set; }
		public DateTime EndDate { get; set; }

		public int TotalSessionsPlayed { get; set; } = 0;
		public int TotalTimePlayedMinutes { get; set; } = 0;

		public decimal AverageScore { get; set; } = 0;
		public decimal AverageEngagementScore { get; set; } = 0;

		public decimal ImprovementRate { get; set; } = 0; // Yüzde olarak
		public string CognitiveMetrics { get; set; } // JSON data
		public string Insights { get; set; }
		public string Recommendations { get; set; }

		public DateTime GeneratedAt { get; set; } = DateTime.UtcNow;
	}
}
