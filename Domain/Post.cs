using System;
using System.Collections.Generic;
using System.Reflection.Metadata;

namespace Domain
{
    public class Post
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Picture { get; set; }
        public string Video { get; set; }
        public int NumberOfCredits { get; set; } 
        public AppUser Mentor { get; set; }
        public ICollection<Comment> Comments { get; set; }=new List<Comment>();
    }
}