using Application.Abstractions;
using Application.Dtos.Category;
using AutoMapper;
using MediatR;

namespace Application.Features.Commands.Category.CreateCategory
{
    public class CreateCategoryQueryHandler : IRequestHandler<CreateCategoryCommandRequest, CreateCategoryCommandResponse>
    {
        private readonly ICategoryService service;
        private readonly IMapper mapper;

        public CreateCategoryQueryHandler(ICategoryService service, IMapper mapper)
        {
            this.service = service;
            this.mapper = mapper;
        }
        public async Task<CreateCategoryCommandResponse> Handle(CreateCategoryCommandRequest request, CancellationToken cancellationToken)
        {
            await service.InsertAsync(mapper.Map<CategoryDto>(request));

            return new CreateCategoryCommandResponse();
        }
    }
}