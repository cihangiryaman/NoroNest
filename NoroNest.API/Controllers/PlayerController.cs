using Microsoft.AspNetCore.Mvc;
using NoroNest.Application.DTOs;
using NoroNest.Domain.Entities;

namespace NoroNest.API.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class PlayerController : ControllerBase
	{
		public PlayerController()
		{
			
		}

		[HttpGet]
		public ScoreDTO GetAllScoresByPatientId()
		{
			return new ScoreDTO
			{
				Id = 1,
				GameId = 1,
				PatientId = 1,
				Value = 100,
				Date = DateTime.UtcNow,
				Attempts = 3,
				CompletionTime = 3.5
			};
		}
	}
}
