namespace PizzaBraz.API.ViewModels.Customer
{
    public class CreateCustomerViewModel
    {
        public string Name { get; set; }
        public string WhatsAppNumber { get; set; }
        public string Email { get; set; }
        public Guid CompanyId { get; set; }
    }
}
