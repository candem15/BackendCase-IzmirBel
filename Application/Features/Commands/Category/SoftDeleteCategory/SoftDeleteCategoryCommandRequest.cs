using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Commands.Category.SoftDeleteCategory
{
    public class SoftDeleteCategoryCommandRequest:IRequest<SoftDeleteCategoryCommandResponse>
    {
        public Guid Id { get; set; }
    }
}
