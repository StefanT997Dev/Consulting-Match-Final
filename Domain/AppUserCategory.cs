using System;

namespace Domain
{
    public class AppUserCategory
    {
        public string AppUserId { get; set; }
        public virtual AppUser AppUser { get; set; }
        public Guid CategoryId { get; set; }
        public virtual Category Category { get; set; }
    }
}