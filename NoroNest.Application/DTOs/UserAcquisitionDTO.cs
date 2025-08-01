using NoroNest.Domain.Models.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoroNest.Application.DTOs
{
	public class UserAcquisitionDTO
	{
		public int Id { get; set; }
		public string UserId { get; set; }
		public string AcquisitionChannel { get; set; } // Organic, Google Ads, Facebook, etc.
		public string Campaign { get; set; }
		public decimal AcquisitionCost { get; set; } = 0;
		public DateTime AcquisitionDate { get; set; } = DateTime.UtcNow;
		public string ReferralData { get; set; } // JSON data
	}
}
