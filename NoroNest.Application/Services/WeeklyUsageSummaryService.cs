using AutoMapper;
using NoroNest.Application.DTOs;
using NoroNest.Application.Interfaces;
using NoroNest.Domain.Models.Identity;
using NoroNest.Domain.Models.UserData;
using NoroNest.Infrastructure.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoroNest.Application.Services
{
	internal class WeeklyUsageSummaryService : BaseService<WeeklyUsageSummary, WeeklyUsageSummaryDTO>, IWeeklyUsageSummaryService
	{
		public WeeklyUsageSummaryService(IUnitOfWork unitOfWork, IMapper mapper, string keyPropertyName = "Id") : base(unitOfWork, mapper, keyPropertyName)
		{
		}
	}
}
