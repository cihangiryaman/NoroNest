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
	public class ChurnRiskAssessmentProfile : Profile
	{
		public ChurnRiskAssessmentProfile()
		{
			CreateMap<ChurnRiskAssessment, ChurnRiskAssessmentDTO>().ReverseMap();
		}
	}
}
