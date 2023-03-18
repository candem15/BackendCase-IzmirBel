using Application.Abstractions;
using AutoMapper;
using MediatR;

namespace Application.Features.Commands.Category.SoftDeleteCategory
{
    public class SoftDeleteCategoryCommandHandler : IRequestHandler<SoftDeleteCategoryCommandRequest, SoftDeleteCategoryCommandResponse>
    {
        private readonly ICategoryService service;
        private readonly IMapper mapper;

        public SoftDeleteCategoryCommandHandler(ICategoryService service,IMapper mapper)
        {
            this.service = service;
            this.mapper = mapper;
        }
        public async Task<SoftDeleteCategoryCommandResponse> Handle(SoftDeleteCategoryCommandRequest request, CancellationToken cancellationToken)
        {
            await service.SoftRemoveAsync(request.Id);

            return new SoftDeleteCategoryCommandResponse();
        }
    }
}