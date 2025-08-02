using AutoMapper;
using NoroNest.Application.DTOs;
using NoroNest.Domain.Models.Game;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoroNest.Application.Profiles
{
	public class GameProfile : Profile
	{
		public GameProfile()
		{
			CreateMap<Game, GameDTO>().ReverseMap();
		}
	}
}
