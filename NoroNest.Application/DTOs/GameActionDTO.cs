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
	public class GameActionDTO
	{
		public int Id { get; set; }
		public int GameSessionId { get; set; }
		public string ActionType { get; set; } // Click, Answer, Pause, Resume, etc.
		public string ActionData { get; set; } // JSON data
		public DateTime Timestamp { get; set; } = DateTime.UtcNow;
		public int ResponseTimeMs { get; set; } = 0;
		public bool IsCorrect { get; set; } = false;
	}
}
