namespace PizzaBraz.API.ViewModels.Product
{
    public class CreateProductViewModel
    {
        public Guid ProductTypeId { get; set; }
        public Guid CompanyId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
    }
}
