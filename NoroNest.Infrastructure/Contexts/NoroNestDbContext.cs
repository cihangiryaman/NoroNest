using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using NoroNest.Domain.Models.Game;
using NoroNest.Domain.Models.Identity;
using NoroNest.Domain.Models.UserData;

namespace NoroNest.Infrastructure.Contexts
{
	public class NoroNestDbContext : IdentityDbContext<User>
	{
		public DbSet<Game> Games { get; set; }
		public DbSet<GameAction> GameActions { get; set; }
		public DbSet<GameLevel> GameLevels { get; set; }
		public DbSet<GameSession> GameSessions { get; set; }

		public DbSet<ChurnRiskAssessment> ChurnRiskAssessments { get; set; }
		public DbSet<UserAcquisition> UserAcquisitions { get; set; }
		public DbSet<PersonalizationSetting> PersonalizationSettings { get; set; }

		public DbSet<ProgressMetric> ProgressMetrics { get; set; }
		public DbSet<ProgressReport> ProgressReports { get; set; }
		public DbSet<WeeklyUsageSummary> WeeklyUsageSummaries { get; set; }

		public DbSet<UserProfile> UserProfiles { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);
			// Set default delete behavior to NoAction
			SetDefaultDeleteBehavior(modelBuilder);
			// Configure Identity
			ConfigureIdentity(modelBuilder);
		}

		private void SetDefaultDeleteBehavior(ModelBuilder modelBuilder)
		{
			foreach (var relationship in modelBuilder.Model.GetEntityTypes()
				.SelectMany(e => e.GetForeignKeys()))
			{
				relationship.DeleteBehavior = DeleteBehavior.NoAction;
			}
		}

		private void ConfigureIdentity(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<User>().ToTable("AspNetUsers", "dbo");
			modelBuilder.Entity<IdentityRole>().ToTable("AspNetRoles", "dbo");
			modelBuilder.Entity<IdentityUserRole<string>>().ToTable("AspNetUserRoles", "dbo");
			modelBuilder.Entity<IdentityUserClaim<string>>().ToTable("AspNetUserClaims", "dbo");
			modelBuilder.Entity<IdentityUserLogin<string>>().ToTable("AspNetUserLogins", "dbo");
			modelBuilder.Entity<IdentityRoleClaim<string>>().ToTable("AspNetRoleClaims", "dbo");
			modelBuilder.Entity<IdentityUserToken<string>>().ToTable("AspNetUserTokens", "dbo");
		}
	}
}
