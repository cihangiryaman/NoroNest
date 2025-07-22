using NoroNest.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoroNest.Domain.Entities
{
	public class Game
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public GameCategoryEnum Category { get; set; } // Hafıza, Dikkat, Dil
		public DifficultyLevelEnum DefaultDifficulty { get; set; }
		public int EstimatedDuration { get; set; } // dakika
		public bool IsActive { get; set; }
	}
}
