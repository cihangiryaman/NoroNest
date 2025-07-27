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
	/// Oyun seviyeleri
	/// </summary>
	[Table("GameLevels")]
	public class GameLevel
	{
		[Key]
		public int Id { get; set; }

		[Required]
		public int GameId { get; set; }

		[ForeignKey("GameId")]
		public virtual Game Game { get; set; }

		public int Level { get; set; }

		[MaxLength(200)]
		public string Name { get; set; }

		public int DifficultyScore { get; set; }

		[MaxLength(1000)]
		public string Configuration { get; set; } // JSON configuration

		public bool IsUnlocked { get; set; } = true;

		// Navigation Properties
		public virtual ICollection<GameSession> GameSessions { get; set; }
	}

}
