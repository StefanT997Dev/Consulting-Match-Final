using System;
using System.Collections.Generic;

namespace Domain
{
    public class Category
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int NumberOfConsultants { get; set; }
        public virtual ICollection<AppUserCategory> Consultants { get; set; } = new List<AppUserCategory>();
        public virtual ICollection<CategorySkill> Skills { get; set; } = new List<CategorySkill>();
    }
}