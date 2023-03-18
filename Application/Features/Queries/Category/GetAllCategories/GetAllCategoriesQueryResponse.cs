using Application.Dtos.Category;

namespace Application.Features.Queries.Category.GetAllCategories
{
    public class GetAllCategoriesQueryResponse
    {
        public List<CategoryDto> Categories { get; set; }
    }
}