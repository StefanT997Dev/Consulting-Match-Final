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
        public ICollection<AppUserCategory> Categories { get; set; }
        public ICollection<AppUserLevel> Levels { get; set; }
        public ICollection<Review> ConsultantReviews { get; set; }
        public ICollection<Review> ClientReviews { get; set; }
        public ICollection<UserFollowing> Followings { get; set; }
        public ICollection<UserFollowing> Followers { get; set; }
    }
}