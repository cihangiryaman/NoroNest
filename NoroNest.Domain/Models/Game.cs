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
	///		Oyun Tanımları
	/// </summary>
	[Table("Games")]
	public class Game
	{
		[Key]
		public int Id { get; set; }

		[Required]
		[MaxLength(200)]
		public string Name { get; set; }

		[MaxLength(1000)]
		public string Description { get; set; }

		[MaxLength(50)]
		public string Category { get; set; } // Memory, Attention, Language, etc.

		[MaxLength(50)]
		public string GameType { get; set; } // Puzzle, Memory, Math, etc.

		public int MinDifficultyLevel { get; set; } = 1;
		public int MaxDifficultyLevel { get; set; } = 10;

		public int AverageSessionDuration { get; set; } // dakika

		[MaxLength(500)]
		public string CognitiveSkills { get; set; } // JSON array

		public bool IsActive { get; set; } = true;

		public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

		// Navigation Properties
		public virtual ICollection<GameSession> GameSessions { get; set; }
		public virtual ICollection<GameLevel> GameLevels { get; set; }
	}
}
