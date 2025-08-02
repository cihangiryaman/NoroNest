using AutoMapper;
using NoroNest.Application.DTOs;
using NoroNest.Domain.Models.UserData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoroNest.Application.Profiles
{
	public class UserAcquisitionProfile : Profile
	{
		public UserAcquisitionProfile()
		{
			CreateMap<UserAcquisition, UserAcquisitionDTO>().ReverseMap();
		}
	}
}
