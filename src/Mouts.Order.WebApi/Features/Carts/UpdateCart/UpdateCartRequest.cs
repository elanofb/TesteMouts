namespace MoutsOrder.WebApi.Features.Carts.UpdateCart
{
    public class UpdateCartRequest
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public DateTime Date { get; set; }
        public List<UpdateCartProductRequest> Products { get; set; } = new();
    }

    public class UpdateCartProductRequest
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
    }
}
