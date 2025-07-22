using MoutsOrder.Common.Validation;
using MediatR;
using MoutsOrder.Domain.Entities;

namespace MoutsOrder.Application.Orders.CreateOrder;

public class CreateOrderCommand : IRequest<CreateOrderResult>
{
    //public Guid Id { get; set; }
    //public string OrderNumber { get; set; }
    //public DateTime OrderDate { get; set; }
    //public string Customer { get; set; }
    //public decimal TotalAmount { get; set; }
    //public string Branch { get; set; }
    //public List<OrderItem> Items { get; set; } = new();
    
    public Guid Id { get; set; }
    public Guid ProductId { get; set; }
    public DateTime CreatedAt { get; set; }
    public string Customer { get; set; }
    public string ExternalId { get; set; }
    public decimal TotalValue { get; set; }
    public List<OrderItem> Items { get; set; } = new();


    public ValidationResultDetail Validate()
    {
        var validator = new CreateOrderCommandValidator();
        var result = validator.Validate(this);
        return new ValidationResultDetail
        {
            IsValid = result.IsValid,
            Errors = result.Errors.Select(o => (ValidationErrorDetail)o)
        };
    }
}