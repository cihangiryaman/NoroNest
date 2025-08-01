using NoroNest.Domain.Models.Game;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoroNest.Application.DTOs
{
	public class GameLevelDTO
	{
		public int Id { get; set; }
		public int GameId { get; set; }
		public int Level { get; set; }
		public string Name { get; set; }
		public int DifficultyScore { get; set; }
		public string Configuration { get; set; } // JSON configuration
		public bool IsUnlocked { get; set; } = true;
	}
}
