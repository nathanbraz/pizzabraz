namespace PizzaBraz.API.ViewModels.Customer
{
    public class CustomerViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string WhatsAppNumber { get; set; }
        public string Email { get; set; }
        public Guid CompanyId { get; set; }
    }
}
