using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoroNest.Application.DTOs
{
	public class GameDTO
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public string Category { get; set; }
		public string GameType { get; set; }
		public int MinDifficultyLevel { get; set; } = 1;
		public int MaxDifficultyLevel { get; set; } = 10;
		public int AverageSessionDuration { get; set; }
		public string CognitiveSkills { get; set; } // JSON array
		public bool IsActive { get; set; } = true;
		public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
	}
}
