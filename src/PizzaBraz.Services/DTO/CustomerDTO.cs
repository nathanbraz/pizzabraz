using PizzaBraz.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaBraz.Services.DTO
{
    public class CustomerDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string WhatsAppNumber { get; set; }
        public string Email { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdateAt { get; set; }

        public Guid CompanyId { get; set; }

        public CustomerDTO() { }

        public CustomerDTO(Guid id, string name, string whatsAppNumber, string email, DateTime createdAt, DateTime? updateAt, Guid companyId)
        {
            Id = id;
            Name = name;
            WhatsAppNumber = whatsAppNumber;
            Email = email;
            CreatedAt = createdAt;
            UpdateAt = updateAt;
            CompanyId = companyId;
        }
    }
}
