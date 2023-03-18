using Application.Abstractions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Commands.Product.SoftDeleteProduct
{
    public class SoftDeleteProductCommandHandler : IRequestHandler<SoftDeleteProductCommandRequest, SoftDeleteProductCommandResponse>
    {
        private readonly IProductService service;

        public SoftDeleteProductCommandHandler(IProductService service)
        {
            this.service = service;
        }
        public async Task<SoftDeleteProductCommandResponse> Handle(SoftDeleteProductCommandRequest request, CancellationToken cancellationToken)
        {
            await service.SoftRemoveAsync(request.Id);

            return new SoftDeleteProductCommandResponse();
        }
    }
}
