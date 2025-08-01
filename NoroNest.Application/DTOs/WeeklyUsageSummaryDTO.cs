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
	public class WeeklyUsageSummaryDTO
	{
		public int Id { get; set; }
		public string UserId { get; set; }
		public int Year { get; set; }
		public int WeekNumber { get; set; }
		public DateTime WeekStart { get; set; }
		public DateTime WeekEnd { get; set; }
		public int SessionsPlayed { get; set; } = 0;
		public int TotalPlayTimeMinutes { get; set; } = 0;
		public int UniqueDaysPlayed { get; set; } = 0;
		public decimal AverageSessionDuration { get; set; } = 0;
		public decimal AverageScore { get; set; } = 0;
		public decimal WeeklyEngagementScore { get; set; } = 0;
		public string GameBreakdown { get; set; } // JSON - hangi oyunu ne kadar oynamış
		public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
	}
}
