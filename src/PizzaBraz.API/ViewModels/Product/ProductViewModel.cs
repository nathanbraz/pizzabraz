namespace PizzaBraz.API.ViewModels.Product
{
    public class ProductViewModel
    {
        public Guid Id { get; set; }
        public Guid ProductTypeId { get; set; }
        public Guid CompanyId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
