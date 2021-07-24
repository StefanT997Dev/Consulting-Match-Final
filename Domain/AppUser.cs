using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace Domain
{
    public class AppUser:IdentityUser
    {
        public string DisplayName { get; set; }
        public string Bio { get; set; }
        public string SalesVideo { get; set; }
        public string ProfilePicture { get; set; }
        public virtual ICollection<AppUserCategory> Categories { get; set; }
        public virtual ICollection<AppUserSkill> Skills { get; set; }
        public virtual ICollection<AppUserLevel> Levels { get; set; }
        public virtual ICollection<Review> ConsultantReviews { get; set; }
        public virtual ICollection<Review> ClientReviews { get; set; }
        public virtual ICollection<Schedule> ConsultantSchedules{ get; set; }
        public virtual ICollection<Schedule> ClientSessions { get; set; }
        public virtual ICollection<UserFollowing> Followings { get; set; }
        public virtual ICollection<UserFollowing> Followers { get; set; }
    }
}