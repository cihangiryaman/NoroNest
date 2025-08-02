using AutoMapper;
using NoroNest.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoroNest.Application.Profiles
{
	public class UserProfileProfile : Profile
	{
		public UserProfileProfile()
		{
			CreateMap<UserProfile, UserProfileDTO>().ReverseMap();
		}
	}
}
