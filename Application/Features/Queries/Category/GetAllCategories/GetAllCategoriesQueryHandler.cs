using Application.Abstractions;
using MediatR;

namespace Application.Features.Queries.Category.GetAllCategories
{
    public class GetAllCategoriesQueryHandler : IRequestHandler<GetAllCategoriesQueryRequest, GetAllCategoriesQueryResponse>
    {
        private readonly ICategoryService service;

        public GetAllCategoriesQueryHandler(ICategoryService service)
        {
            this.service = service;
        }
        public async Task<GetAllCategoriesQueryResponse> Handle(GetAllCategoriesQueryRequest request, CancellationToken cancellationToken)
        {
            var result = await service.GetAllAsync();

            return new GetAllCategoriesQueryResponse() { Categories = result.ToList() };
        }
    }
}