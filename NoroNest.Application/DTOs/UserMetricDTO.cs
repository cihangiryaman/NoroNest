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
	public class UserMetricDTO
	{
		public int Id { get; set; }
		public string UserId { get; set; }
		public string MetricType { get; set; } // EngagementScore, ChurnRisk, WeeklyPlayTime, etc.
		public decimal MetricValue { get; set; }
		public DateTime MeasuredAt { get; set; } = DateTime.UtcNow;
		public string TimeFrame { get; set; } // Daily, Weekly, Monthly
		public string AdditionalData { get; set; } // JSON for extra context
	}
}
