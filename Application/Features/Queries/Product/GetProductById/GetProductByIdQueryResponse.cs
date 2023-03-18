namespace Application.Features.Queries.Product.GetProductById
{
    public class GetProductByIdQueryResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public float Quantity { get; set; }
        public string Unit { get; set; }
        public string CategoryName { get; set; }
    }
}