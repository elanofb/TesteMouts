using MediatR;

namespace MoutsOrder.WebApi.Features.Carts.CreateCart
{
    public class CreateCartRequest : IRequest<CreateCartResponse>
    {
        public Guid UserId { get; set; }
        public DateTime Date { get; set; }
        public List<CreateCartProductRequest> Products { get; set; } = new();
    }

    public class CreateCartProductRequest
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
    }
}