using NoroNest.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoroNest.Domain.Entities
{
	public class GameSession
	{
		public int Id { get; set; }

		public int PatientId { get; set; }
		[ForeignKey(nameof(PatientId))]
		public Patient Patient { get; set; }

		public int GameId { get; set; }
		[ForeignKey(nameof(GameId))]
		public Game Game { get; set; }

		public DateTime StartTime { get; set; }
		public DateTime? EndTime { get; set; }
		public int? FinalScore { get; set; }
		public DifficultyLevelEnum Difficulty { get; set; }
		public bool Completed { get; set; }
		public string? Notes { get; set; }
	}
}
