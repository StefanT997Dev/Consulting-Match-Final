using System;

namespace Application.DTOs
{
    public class MessageDto
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Content { get; set; }
        public string Username { get; set; }
        public string Image { get; set; }
    }
}