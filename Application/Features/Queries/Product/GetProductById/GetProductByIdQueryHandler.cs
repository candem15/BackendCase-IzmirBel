using Application.Abstractions;
using AutoMapper;
using MediatR;

namespace Application.Features.Queries.Product.GetProductById
{
    public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQueryRequest, GetProductByIdQueryResponse>
    {
        private readonly IProductService service;
        private readonly IMapper mapper;

        public GetProductByIdQueryHandler(IProductService service,IMapper mapper)
        {
            this.service = service;
            this.mapper = mapper;
        }
        public async Task<GetProductByIdQueryResponse> Handle(GetProductByIdQueryRequest request, CancellationToken cancellationToken)
        {
            var result = await service.GetByIdAsync(request.Id);

            return mapper.Map<GetProductByIdQueryResponse>(result);
        }
    }
}