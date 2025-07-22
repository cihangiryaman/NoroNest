using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using NoroNest.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace NoroNest.Infrastructure.Contexts
{
	public class NoroNestDbContext : DbContext
	{
		public DbSet<Score> Scores { get; set; }
		public DbSet<Patient> Patients { get; set; }
		public DbSet<PatientSymptom> PatientSymptoms { get; set; }
		public DbSet<Symptom> Symptoms { get; set; }
		public DbSet<Game> Games { get; set; }
		public DbSet<Achievement> Achievements { get; set; }
		public DbSet<GameSession> GameSessions { get; set; }
		public DbSet<Relative> Relatives { get; set; }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			var basePath = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).FullName, "NoroNest.API");

			var configuration = new ConfigurationBuilder()
				.SetBasePath(basePath)
				.AddJsonFile("appsettings.json", optional: false)
				.Build();

			var connectionString = configuration.GetConnectionString("DevelopmentConnection");

			optionsBuilder.UseSqlServer(connectionString);
		}
	}
}
