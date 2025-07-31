using NoroNest.Domain.Models.Game;
using NoroNest.Domain.Models.Identity;
using NoroNest.Infrastructure.Contexts;
using NoroNest.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoroNest.Domain.Interfaces
{
	public class GameActionRepository : Repository<GameAction>, IGameActionRepository
	{
		public GameActionRepository(NoroNestDbContext context) : base(context)
		{
		}
	}
}
