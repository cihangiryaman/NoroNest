﻿using AutoMapper;
using NoroNest.Application.DTOs;
using NoroNest.Domain.Models.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoroNest.Application.Profiles
{
	public class UserProfile : Profile
	{
		public UserProfile()
		{
			CreateMap<User, UserDTO>().ReverseMap();
		}
	}
}
