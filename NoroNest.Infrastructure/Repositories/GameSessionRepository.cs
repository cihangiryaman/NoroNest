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
	public class GameSessionRepository : Repository<GameSession>, IGameSessionRepository
	{
		public GameSessionRepository(NoroNestDbContext context) : base(context)
		{
		}
	}
}
