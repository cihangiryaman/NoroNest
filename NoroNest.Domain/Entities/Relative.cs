using NoroNest.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoroNest.Domain.Entities
{
	[Table("Relatives")]
	public class Relative
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string PhoneNumber { get; set; }
		public string Email { get; set; }
		public DateTime? DateOfBirth { get; set; }
		public RelationshipEnum Relationship { get; set; }

		public int PatientId { get; set; }
		[ForeignKey(nameof(PatientId))]
		public Patient Patient { get; set; }
	}
}
