namespace PizzaBraz.API.ViewModels.Order
{
    public class CreateOrderViewModel
    {
        public Guid CustomerId { get; set; }
        public Guid CompanyId { get; set; }
        public decimal Total { get; set; }
    }
}
