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
	public class ProgressMetricDTO
	{
		public int Id { get; set; }
		public int ProgressReportId { get; set; }
		public string MetricName { get; set; }
		public decimal MetricValue { get; set; }
		public decimal PreviousValue { get; set; } = 0;
		public decimal ChangePercentage { get; set; } = 0;
		public string MetricUnit { get; set; } // Score, Minutes, Percentage, etc.
		public string Description { get; set; }
	}
}
