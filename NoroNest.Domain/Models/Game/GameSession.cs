using NoroNest.Domain.Models.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoroNest.Domain.Models.Game
{
	/// <summary>
	/// Oyun oturumları
	/// </summary>
	[Table("GameSession")]
	public class GameSession
	{
		[Key]
		public int Id { get; set; }

		[Required]
		public string UserId { get; set; }

		[ForeignKey("UserId")]
		public virtual User User { get; set; }

		[Required]
		public int GameId { get; set; }

		[ForeignKey("GameId")]
		public virtual Game Game { get; set; }

		public int? GameLevelId { get; set; }

		[ForeignKey("GameLevelId")]
		public virtual GameLevel GameLevel { get; set; }

		public DateTime StartTime { get; set; }
		public DateTime? EndTime { get; set; }

		public int DurationInSeconds { get; set; }

		public decimal Score { get; set; } = 0;
		public decimal MaxScore { get; set; } = 0;

		public int CorrectAnswers { get; set; } = 0;
		public int TotalQuestions { get; set; } = 0;

		public bool IsCompleted { get; set; } = false;

		[MaxLength(50)]
		public string SessionStatus { get; set; } // Completed, Abandoned, Failed

		[MaxLength(1000)]
		public string SessionData { get; set; } // JSON data for detailed analytics

		public decimal EngagementScore { get; set; } = 0;

		// Navigation Properties
		public virtual ICollection<GameAction> GameActions { get; set; }
	}
}
