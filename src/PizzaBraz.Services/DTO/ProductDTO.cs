using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaBraz.Services.DTO
{
    public class ProductDTO
    {
        public Guid Id { get; set; }
        public Guid ProductTypeId { get; set; }
        public Guid CompanyId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public ProductDTO() {}
        public ProductDTO(Guid id, Guid productTypeId, Guid companyId, string name, string description, decimal price, DateTime createdAt, DateTime? updatedAt)
        {
            Id = id;
            ProductTypeId = productTypeId;
            CompanyId = companyId;
            Name = name;
            Description = description;
            Price = price;
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
        }

    }
}
