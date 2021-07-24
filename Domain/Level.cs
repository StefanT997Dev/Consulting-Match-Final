using System;
using System.Collections.Generic;

namespace Domain
{
    public class Level
    {
        public Guid Id { get; set; }
        public int LevelNumber { get; set; }
        public int CreditsNeeded { get; set; }
        public string LevelName { get; set; }
        public virtual Category Category { get; set; }
        public virtual ICollection<AppUserLevel> Consultants { get; set; }
    }
}