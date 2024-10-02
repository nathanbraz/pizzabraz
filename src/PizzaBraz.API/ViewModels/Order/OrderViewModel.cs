using PizzaBraz.Domain.Enums;

namespace PizzaBraz.API.ViewModels.Order
{
    public class OrderViewModel
    {
        public Guid CustomerId { get; set; }
        public Guid CompanyId { get; set; }
        public OrderStatusEnum Status { get; set; }
        public decimal Total { get; set; }
    }
}
