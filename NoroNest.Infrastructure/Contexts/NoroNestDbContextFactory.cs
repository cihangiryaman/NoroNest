using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoroNest.Infrastructure.Contexts
{
	public class NoroNestDbContextFactory : IDesignTimeDbContextFactory<NoroNestDbContext>
	{
		public NoroNestDbContext CreateDbContext(string[] args)
		{
			// Load configuration from appsettings.json
			var basePath = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).FullName, "NoroNest.API");

			var configuration = new ConfigurationBuilder()
				.SetBasePath(basePath)
				.AddJsonFile("appsettings.json", optional: false)
				.Build();


			var optionsBuilder = new DbContextOptionsBuilder<NoroNestDbContext>();

			// Get connection string (fallback if needed)
			var connectionString = configuration.GetConnectionString("DevelopmentConnection");

			optionsBuilder.UseSqlServer(connectionString);

			return new NoroNestDbContext(optionsBuilder.Options);
		}
	}
}
