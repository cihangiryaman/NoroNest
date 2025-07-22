using NoroNest.Domain.Entities.Common;
using NoroNest.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoroNest.Domain.Entities
{
	[Table("Patients")]
	public class Patient : BaseEntity
	{
		public string Name { get; set; }
		public bool Gender { get; set; }
		public string PhoneNumber { get; set; }
		public string? Occupation { get; set; }
		public string Email { get; set; }
		public DateTime DateOfBirth { get; set; }
		public DiseaseStageEnum DiseaseStage { get; set; }
		public PhysicalActivityLevelEnum PhysicalActivityLevel { get; set; }
		public int HoursPlayed { get; set; }

		public int EmergencyContactId { get; set; }
		[ForeignKey(nameof(EmergencyContactId))]
		public Relative EmergencyContact { get; set; }
	}
}
