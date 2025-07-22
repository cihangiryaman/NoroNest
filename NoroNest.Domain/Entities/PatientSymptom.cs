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
	public class PatientSymptom : BaseEntity
	{
		public int PatientId { get; set; }
		[ForeignKey(nameof(PatientId))]
		public Patient Patient { get; set; }

		public int SymptomId { get; set; }
		[ForeignKey(nameof(SymptomId))]
		public Symptom Symptom { get; set; }

		public SymptomSeverityEnum Severity { get; set; }
	}
}
