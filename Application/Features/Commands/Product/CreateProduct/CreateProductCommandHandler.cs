using Application.Abstractions;
using Application.Dtos.Product;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Commands.Product.CreateProduct
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommandRequest, CreateProductCommandResponse>
    {
        private readonly IProductService service;
        private readonly IMapper mapper;

        public CreateProductCommandHandler(IProductService service, IMapper mapper)
        {
            this.service = service;
            this.mapper = mapper;
        }
        public async Task<CreateProductCommandResponse> Handle(CreateProductCommandRequest request, CancellationToken cancellationToken)
        {
            await service.InsertAsync(mapper.Map<CreateProductDto>(request));

            return new CreateProductCommandResponse();
        }
    }
}
