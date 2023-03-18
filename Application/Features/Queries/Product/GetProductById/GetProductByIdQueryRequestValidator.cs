using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Queries.Product.GetProductById
{
    public class GetProductByIdQueryRequestValidator:AbstractValidator<GetProductByIdQueryRequest>
    {
        public GetProductByIdQueryRequestValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Invalid id entered!");
        }
    }
}
