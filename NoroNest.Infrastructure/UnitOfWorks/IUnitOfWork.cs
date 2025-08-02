using NoroNest.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoroNest.Infrastructure.UnitOfWorks
{
	public interface IUnitOfWork
	{
		//IChurnRiskAssessmentRepository ChurnRiskAssessment { get; }

		Task<List<T>> QueryAsync<T>(string sql, object parameters = null) where T : class;

		IRepository<T> GetRepository<T>() where T : class;

		Task<int> SaveChangesAsync();
	}
}
