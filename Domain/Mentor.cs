using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
	public class Mentor
	{
		public int Id { get; set; }
		public string FirstAndLastName { get; set; }
		public string Bio { get; set; }
		public byte[] Photo { get; set; }
		public string Category { get; set; }
		public List<string> Skills { get; set; }
	}
}
