using System.Collections.Generic;
using Domain;

namespace Application.DTOs
{
    public class MentorDisplayDto
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
		public string LastName { get; set; }
		public string Bio { get; set; }
        public byte[] Image { get; set; }
        public string WorksAt { get; set; }
		public CategoryDto Category { get; set; }
		public ICollection<SkillDto> Skills { get; set; }
    }
}