using AutoMapper;
using NoroNest.Application.DTOs;
using NoroNest.Application.Interfaces;
using NoroNest.Domain.Entities;
using NoroNest.Infrastructure.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoroNest.Application.Services
{
	public class PatientService : BaseService<Patient,PatientDTO>, IPatientService
	{
		public PatientService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
		{

		}
	}
}
