using AutoMapper;
using NoroNest.Application.DTOs;
using NoroNest.Application.Interfaces;
using NoroNest.Domain.Models.Game;
using NoroNest.Domain.Models.Identity;
using NoroNest.Infrastructure.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoroNest.Application.Services
{
	public class GameSessionService : BaseService<GameSession, GameSessionDTO>, IGameSessionService
	{
		public GameSessionService(IUnitOfWork unitOfWork, IMapper mapper, string keyPropertyName = "Id") : base(unitOfWork, mapper, keyPropertyName)
		{
		}
	}
}
