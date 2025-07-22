using NoroNest.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoroNest.Application.DTOs
{
	public class ScoreDTO
	{
		public int Id { get; set; }
		public int GameId { get; set; }
		public int PatientId { get; set; }
		public int Value { get; set; }
		public DateTime Date { get; set; }
		public int Attempts { get; set; }
		public double CompletionTime { get; set; }
	}
}
