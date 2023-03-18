using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Commands.Product.SoftDeleteProduct
{
    public class SoftDeleteProductCommandRequestValidator:AbstractValidator<SoftDeleteProductCommandRequest>
    {
        public SoftDeleteProductCommandRequestValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Invalid id entered!");
        }
    }
}
