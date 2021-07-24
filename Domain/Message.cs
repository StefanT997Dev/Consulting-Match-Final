using System;

namespace Domain
{
    public class Message
    {
        public Guid Id { get; set; }
        public string Content { get; set; }
        public virtual AppUser Consultant { get; set; }
    }
}