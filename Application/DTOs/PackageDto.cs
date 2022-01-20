using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
	public class PackageDto
	{
		[Required]
		[Range(20, 200, ErrorMessage = "Broj sesija mora biti između 20 i 200")]
		public int NumberOfSessions { get; set; }
		[Required]
		[Range(3, 6, ErrorMessage = "Mentorstvo mora trajati između 3 i 6 meseci")]
		public int DurationInMonths { get; set; }
		[Required]
		public string MentorId { get; set; }
	}
}
