using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Queries.Category.GetCategoryById
{
    public class GetCategoryByIdQueryRequestValidator : AbstractValidator<GetCategoryByIdQueryRequest>
    {
        public GetCategoryByIdQueryRequestValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Invalid id entered!");
        }
    }
}
