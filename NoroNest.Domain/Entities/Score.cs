using NoroNest.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoroNest.Domain.Entities
{
	public class Score
	{
		public int Id { get; set; }

		public int GameId { get; set; }
		[ForeignKey(nameof(GameId))]
		public Game Game { get; set; }

		public int PatientId { get; set; }
		[ForeignKey(nameof(PatientId))]
		public Patient Patient { get; set; }

		public int Value { get; set; }
		public DateTime Date { get; set; }
		public int Attempts { get; set; }
		public double CompletionTime { get; set; }
	}
}
