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
	public class WeeklyUsageSummaryProfile : Profile
	{
		public WeeklyUsageSummaryProfile()
		{
			CreateMap<WeeklyUsageSummary, WeeklyUsageSummaryDTO>().ReverseMap();
		}
	}
}
