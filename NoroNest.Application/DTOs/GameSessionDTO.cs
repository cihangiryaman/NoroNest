using NoroNest.Domain.Models.Game;
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
	public class GameSessionDTO
	{
		public int Id { get; set; }
		public string UserId { get; set; }
		public virtual User User { get; set; }
		public int GameId { get; set; }
		public int GameLevelId { get; set; }
		public DateTime StartTime { get; set; }
		public DateTime? EndTime { get; set; }
		public int DurationInSeconds { get; set; }
		public decimal Score { get; set; } = 0;
		public decimal MaxScore { get; set; } = 0;
		public int CorrectAnswers { get; set; } = 0;
		public int TotalQuestions { get; set; } = 0;
		public bool IsCompleted { get; set; } = false;
		public string SessionStatus { get; set; } // Completed, Abandoned, Failed
		public string SessionData { get; set; } // JSON data for detailed analytics
		public decimal EngagementScore { get; set; } = 0;
	}
}
