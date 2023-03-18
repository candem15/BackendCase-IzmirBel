using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Commands.Category.UpdateCategory
{
    public class UpdateCategoryCommandRequestValidator : AbstractValidator<UpdateCategoryCommandRequest>
    {
        public UpdateCategoryCommandRequestValidator()
        {
            RuleFor(x=>x.Id).NotEmpty().WithMessage("Invalid id entered!");
            RuleFor(x => x.Description).MaximumLength(250);
            RuleFor(x => x.Name).NotEmpty().MaximumLength(50);
        }
    }
}
