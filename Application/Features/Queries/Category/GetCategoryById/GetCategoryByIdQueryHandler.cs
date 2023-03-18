using Application.Abstractions;
using AutoMapper;
using MediatR;

namespace Application.Features.Queries.Category.GetCategoryById
{
    public class GetCategoryByIdQueryHandler : IRequestHandler<GetCategoryByIdQueryRequest, GetCategoryByIdQueryResponse>
    {
        private readonly ICategoryService service;
        private readonly IMapper mapper;

        public GetCategoryByIdQueryHandler(ICategoryService service, IMapper mapper)
        {
            this.service = service;
            this.mapper = mapper;
        }
        public async Task<GetCategoryByIdQueryResponse> Handle(GetCategoryByIdQueryRequest request, CancellationToken cancellationToken)
        {
            var result = await service.GetByIdAsync(request.Id);

            return mapper.Map<GetCategoryByIdQueryResponse>(result);
        }
    }
}