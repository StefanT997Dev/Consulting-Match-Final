using System;
using System.Collections.Generic;

namespace Domain
{
    public class Category
    {
		public Guid Id { get; set; }
		public string Name { get; set; }
		public ICollection<AppUser> Mentors { get; set; }
		public ICollection<CategorySkill> Skills { get; set; }
	}
}