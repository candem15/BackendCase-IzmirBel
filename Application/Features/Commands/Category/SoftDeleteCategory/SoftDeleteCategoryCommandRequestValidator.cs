using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Commands.Category.SoftDeleteCategory
{
    public class SoftDeleteCategoryCommandRequestValidator : AbstractValidator<SoftDeleteCategoryCommandRequest>
    {
        public SoftDeleteCategoryCommandRequestValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Invalid id entered!");
        }
    }
}
