using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
	public class ClientDashboardDisplayDto
	{
		public string DisplayName { get; set; }
		public int TotalNumberOfSessions { get; set; }
		public int NumberOfSessionsLeft { get; set; }
		public string ZoomLink { get; set; }
	}
}
