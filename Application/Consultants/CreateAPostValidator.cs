using Application.DTOs;
using Domain;
using FluentValidation;

namespace Application.Consultants
{
    public class CreateAPostValidator : AbstractValidator<PostDto>
    {
        public CreateAPostValidator()
        {
            RuleFor(p => p.Title).NotEmpty();
            RuleFor(p=>p.Description).NotEmpty();
        }
    }
}