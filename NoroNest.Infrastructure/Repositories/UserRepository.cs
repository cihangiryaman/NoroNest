using NoroNest.Domain.Interfaces;
using NoroNest.Domain.Models.Identity;
using NoroNest.Infrastructure.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace NoroNest.Infrastructure.Repositories
{
	public class UserRepository : Repository<User>, IUserRepository
	{
		public UserRepository(NoroNestDbContext context) : base(context)
		{
		}
	}
}
