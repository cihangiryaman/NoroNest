using NoroNest.Domain.Interfaces;
using NoroNest.Domain.Models.Game;
using NoroNest.Infrastructure.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoroNest.Infrastructure.Repositories
{
	public class GameLevelRepository : Repository<GameLevel>, IGameLevelRepository
	{
		public GameLevelRepository(NoroNestDbContext context) : base(context)
		{
		}
	}
}
