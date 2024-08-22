using PizzaBraz.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaBraz.Infra.Interfaces
{
    public interface IBaseRepository<T> where T : Base
    {
        Task<T> Create(T obg);
        Task<T> Update(T obg);
        Task Remove(Guid id);
        Task<T> Get(Guid id);
        Task<List<T>> GetAll();

    }
}
