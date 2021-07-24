using System;

namespace Domain
{
    public class AppUserSkill
    {
        public string ConsultantId { get; set; }
        public virtual AppUser Consultant { get; set; }
        public Guid SkillId { get; set; }
        public virtual Skill Skill { get; set; }
    }
}