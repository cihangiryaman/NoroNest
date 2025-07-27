using NoroNest.Domain.Models;
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
	/// Oyun içi aksiyonlar (detaylı tracking için)
	/// </summary>
	[Table("GameActions")]
	public class GameAction
	{
		[Key]
		public int Id { get; set; }

		[Required]
		public int GameSessionId { get; set; }

		[ForeignKey("GameSessionId")]
		public virtual GameSession GameSession { get; set; }

		[MaxLength(100)]
		public string ActionType { get; set; } // Click, Answer, Pause, Resume, etc.

		[MaxLength(1000)]
		public string ActionData { get; set; } // JSON data

		public DateTime Timestamp { get; set; } = DateTime.UtcNow;

		public int ResponseTimeMs { get; set; } = 0;

		public bool IsCorrect { get; set; } = false;
	}
}
