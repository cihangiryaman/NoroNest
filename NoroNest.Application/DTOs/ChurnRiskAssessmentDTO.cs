using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoroNest.Application.DTOs
{
	public class ChurnRiskAssessmentDTO
	{
		public int Id { get; set; }
		public int UserId { get; set; }
		public string UserFullName { get; set; }
		public decimal ChurnRiskScore { get; set; }
		public string RiskLevel { get; set; }
		public string RiskFactors { get; set; }
		public int DaysSinceLastSession { get; set; } = 0;
		public decimal EngagementTrend { get; set; } = 0;
		public DateTime AssessedAt { get; set; } = DateTime.UtcNow;
		public DateTime? InterventionDate { get; set; }
		[MaxLength(1000)]
		public string RecommendedActions { get; set; }
	}
}
