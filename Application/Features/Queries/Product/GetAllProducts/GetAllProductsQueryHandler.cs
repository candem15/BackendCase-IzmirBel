using Application.Abstractions;
using MediatR;

namespace Application.Features.Queries.Product.GetAllProducts
{
    public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQueryRequest, GetAllProductsQueryResponse>
    {
        private readonly IProductService service;

        public GetAllProductsQueryHandler(IProductService service)
        {
            this.service = service;
        }
        public async Task<GetAllProductsQueryResponse> Handle(GetAllProductsQueryRequest request, CancellationToken cancellationToken)
        {
            var result = await service.GetAllAsync();

            return new GetAllProductsQueryResponse() { Products = result.ToList() };
        }
    }
}