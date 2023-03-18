using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Commands.Category.CreateCategory
{
    public class CreateCategoryCommandRequestValidator : AbstractValidator<CreateCategoryCommandRequest>
    {
        public CreateCategoryCommandRequestValidator()
        {
            RuleFor(x=>x.Name).NotEmpty().MaximumLength(50);
        }
    }
}
