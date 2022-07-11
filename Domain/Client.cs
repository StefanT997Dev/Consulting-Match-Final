using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
	public class Client
	{
		public int Id { get; set; }
		public string FirstAndLastName { get; set; }
        public string Email { get; set; }
        public string TotalBudget { get; set; }
        public string FieldOfInterest { get; set; }
        public string EnglishLevel { get; set; }
        public string ExpectedSalary { get; set; }
    }
}
