using System;

namespace Domain
{
    public class AppUserLevel
    {
        public string AppUserId { get; set; }
        public virtual AppUser AppUser { get; set; }
        public Guid LevelId { get; set; }
        public virtual Level Level { get; set; }
        public int NumberOfCredits { get; set; }
    }
}