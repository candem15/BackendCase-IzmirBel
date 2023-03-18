using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Commands.Product.UpdateProduct
{
    public class UpdateProductCommandRequestValidator:AbstractValidator<UpdateProductCommandRequest>
    {
        public UpdateProductCommandRequestValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Invalid id entered!");
            RuleFor(x => x.Price).NotEmpty().GreaterThanOrEqualTo(0);
            RuleFor(x => x.Unit).NotEmpty().MaximumLength(10);
            RuleFor(x => x.Quantity).NotEmpty().GreaterThanOrEqualTo(0);
            RuleFor(x => x.Description).MaximumLength(250);
            RuleFor(x => x.Name).NotEmpty().MaximumLength(50);
        }
    }
}
