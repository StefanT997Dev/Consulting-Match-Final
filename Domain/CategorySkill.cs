using System;

namespace Domain
{
    public class CategorySkill
    {
        public Guid SkillId { get; set; }
        public virtual Skill Skill { get; set; }
        public Guid CategoryId { get; set; }
        public virtual Category Category { get; set; }
    }
}