using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoroNest.Domain.Models.Identity
{
	/// <summary>
	///		ASP.NET Identity User'ınından genişletilmiş sınıf.
	/// </summary>
	[Table("AspNetUsers", Schema = "dbo")]
	public class User : IdentityUser
	{
		[Required]
		[MaxLength(100)]
		public string FirstName { get; set; }

		[Required]
		[MaxLength(100)]
		public string LastName { get; set; }

		public DateTime DateOfBirth { get; set; }

		[MaxLength(10)]
		public string Gender { get; set; }

		public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
		public DateTime? LastLoginAt { get; set; }
		public bool IsActive { get; set; } = true;

		// Navigation Properties
		public virtual UserProfile UserProfile { get; set; }
		public virtual ICollection<GameSession> GameSessions { get; set; }
		public virtual ICollection<ProgressReport> ProgressReports { get; set; }
		public virtual ICollection<UserMetric> UserMetrics { get; set; }
		public virtual ICollection<AIRecommendation> AIRecommendations { get; set; }
	}
}
