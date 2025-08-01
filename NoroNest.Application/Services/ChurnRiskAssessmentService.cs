using AutoMapper;
using NoroNest.Application.DTOs;
using NoroNest.Domain.Models.UserData;
using NoroNest.Infrastructure.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoroNest.Application.Services
{
	public class ChurnRiskAssessmentService : BaseService<ChurnRiskAssessment, ChurnRiskAssessmentDTO>
	{
		public ChurnRiskAssessmentService(IUnitOfWork unitOfWork, IMapper mapper, string keyPropertyName = "Id")
			: base(unitOfWork, mapper, keyPropertyName)
		{
		}
		// Burada churn risk değerlendirmesi ile ilgili özel metotlar eklenebilir
		// Örneğin: Kullanıcı bazında risk değerlendirmesi yapma, raporlama vb.
	}
}
