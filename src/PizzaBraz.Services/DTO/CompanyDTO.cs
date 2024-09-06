using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaBraz.Services.DTO
{
    public class CompanyDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string CNPJ { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Subdomain { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdateAt { get; set; }

        public CompanyDTO() { }

        public CompanyDTO(string name, string description, string cnpj, string address, string phone, string email, string subdomain, DateTime createdAt, DateTime updateAt)
        {
            Name = name;
            Description = description;
            CNPJ = cnpj;
            Address = address;
            Phone = phone;
            Email = email;
            Subdomain = subdomain;
            CreatedAt = createdAt;
            UpdateAt = updateAt;
        }
    }
}
