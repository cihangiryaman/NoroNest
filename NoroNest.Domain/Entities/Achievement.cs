using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoroNest.Domain.Entities
{
	public class Achievement
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public int GameId { get; set; }
		[ForeignKey(nameof(GameId))]
		public Game Game { get; set; }
	}
}
