using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
	public class PackageDto
	{
		public int Id { get; set; }
		public int NumberOfSessions { get; set; }
		public int DurationInMonths { get; set; }
		public string MentorId { get; set; }
	}
}
