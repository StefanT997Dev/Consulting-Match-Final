using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public class ClientsMentorDto
    {
        public string DisplayName { get; set; }
        public int SessionsDone { get; set; }
        public int TotalNumberOfSessions { get; set; }
        public DateTime NextSessionDate { get; set; }
    }
}
