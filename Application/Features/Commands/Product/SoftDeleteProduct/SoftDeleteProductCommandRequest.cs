using MediatR;

namespace Application.Features.Commands.Product.SoftDeleteProduct
{
    public class SoftDeleteProductCommandRequest :IRequest<SoftDeleteProductCommandResponse>
    {
        public Guid Id { get; set; }
    }
}
