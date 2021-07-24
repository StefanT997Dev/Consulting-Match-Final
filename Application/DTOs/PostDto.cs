using System;

namespace Application.DTOs
{
    public class PostDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}