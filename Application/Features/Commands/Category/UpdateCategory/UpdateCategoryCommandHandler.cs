using Application.Abstractions;
using AutoMapper;
using MediatR;

namespace Application.Features.Commands.Category.UpdateCategory
{
    public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommandRequest, UpdateCategoryCommandResponse>
    {
        private readonly ICategoryService service;
        private readonly IMapper mapper;

        public UpdateCategoryCommandHandler(ICategoryService service, IMapper mapper)
        {
            this.service = service;
            this.mapper = mapper;
        }
        public async Task<UpdateCategoryCommandResponse> Handle(UpdateCategoryCommandRequest request, CancellationToken cancellationToken)
        {
            await service.UpdateAsync(new Dtos.Category.CategoryDto()
            {
                Description = request.Description,
                Name = request.Name,
                Id = request.Id
            });

            return new UpdateCategoryCommandResponse();
        }
    }
}