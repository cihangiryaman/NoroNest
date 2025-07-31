using NoroNest.Domain.Models.Identity;
using NoroNest.Domain.Models.UserData;
using NoroNest.Infrastructure.Contexts;
using NoroNest.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoroNest.Domain.Interfaces
{
	public class ProgressReportRepository : Repository<ProgressReport>, IProgressReportRepository
	{
		public ProgressReportRepository(NoroNestDbContext context) : base(context)
		{
		}
	}
}
