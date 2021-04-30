using System;
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
        public AppUser Consultant { get; set; }
    }
}