using Application.DTOs;
using Domain;
using FluentValidation;

namespace Application.Categories
{
    public class CategoriesValidator : AbstractValidator<CreateCategoryDto>
    {
        public CategoriesValidator()
        {
            RuleFor(x => x.Name).NotEmpty();
        }
    }
}