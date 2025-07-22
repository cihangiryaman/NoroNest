using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace NoroNest.Application.Interfaces
{
	public interface IBaseService<TDTO>
	{
		Task Add(TDTO entity);
		Task Update(TDTO entity);
		Task Delete(TDTO entity);
		Task DeleteById(int id);
		Task DeleteRange(List<TDTO> entities);
		Task<List<TDTO>> GetAll();
		Task<List<TDTO>> Get(Expression<Func<TDTO, bool>> filter);
		Task<TDTO> GetById(int id);
	}
}
