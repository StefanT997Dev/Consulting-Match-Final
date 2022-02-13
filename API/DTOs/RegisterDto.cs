using Domain;
using System.ComponentModel.DataAnnotations;

namespace API.DTOs
{
    public class RegisterDto
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string TotalBudget { get; set; } 
        [Required]
        public string FieldOfInterest { get; set; }
        [Required]
        public string EnglishLevel { get; set; }
        [Required]
        public string ExpectedSalary { get; set; }
    }
}