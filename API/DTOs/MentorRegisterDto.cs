using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API.DTOs
{
	public class MentorRegisterDto
	{
        [Required(ErrorMessage = "Morate uneti korisničko ime")]
        public string UserName { get; set; }
		[Required(ErrorMessage = "Morate uneti svoj e-mail")]
		[EmailAddress]
		public string Email { get; set; }
		[Required(ErrorMessage = "Morate uneti password")]
		[StringLength(25, ErrorMessage = "Dužina šifre mora biti između 5 i 25 karaktera", MinimumLength = 5)]
		public string Password { get; set; }
        [Required(ErrorMessage = "Morate odabrati svoju oblast")]
        public string CategoryName { get; set; }
    }
}
