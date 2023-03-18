using Application.Abstractions;
using Application.Dtos.Product;
using AutoMapper;
using MediatR;

namespace Application.Features.Commands.Product.UpdateProduct
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommandRequest, UpdateProductCommandResponse>
    {
        private readonly IProductService service;
        private readonly IMapper mapper;

        public UpdateProductCommandHandler(IProductService service, IMapper mapper)
        {
            this.service = service;
            this.mapper = mapper;
        }
        public async Task<UpdateProductCommandResponse> Handle(UpdateProductCommandRequest request, CancellationToken cancellationToken)
        {
            await service.UpdateAsync(request.Id, mapper.Map<UpdateProductDto>(request));

            return new UpdateProductCommandResponse();
        }
    }
}