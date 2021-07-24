using Domain;
using FluentValidation;

namespace Application.Posts
{
    public class PostsValidator : AbstractValidator<Post>
    {
        public PostsValidator()
        {
            RuleFor(x => x.Title).NotEmpty();
            RuleFor(x => x.Description).NotEmpty();
        }
    }
}