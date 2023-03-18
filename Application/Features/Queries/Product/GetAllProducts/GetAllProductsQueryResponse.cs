using Application.Dtos.Product;

namespace Application.Features.Queries.Product.GetAllProducts
{
    public class GetAllProductsQueryResponse
    {
        public List<ProductDto> Products { get; set; }
    }
}