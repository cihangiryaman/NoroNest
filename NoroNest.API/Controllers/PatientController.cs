using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NoroNest.Application.DTOs;
using NoroNest.Application.Interfaces;
using NoroNest.Domain.Interfaces;

namespace NoroNest.API.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class PatientController : ControllerBase
	{
		IPatientService _patientService;	
		ILogger<PatientController> _logger;

		public PatientController(IPatientService patientService)
		{
			_patientService = patientService;
		}

		[HttpPost("/AddPatient")]
		public async void AddPatient(PatientDTO patient)
		{
			try
			{
				await _patientService.Add(patient);
			}
			catch(Exception ex)
			{
				_logger.LogError(ex, "Error adding patient");
			}
		}
	}
}
