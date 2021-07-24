using System;
using System.Collections.Generic;

namespace Domain
{
    public class Skill
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<CategorySkill> Categories { get; set; }=new List<CategorySkill>();
        public virtual ICollection<AppUserSkill> Consultants { get; set; }=new List<AppUserSkill>();
    }
}