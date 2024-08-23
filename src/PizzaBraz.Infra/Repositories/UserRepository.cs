using Microsoft.EntityFrameworkCore;
using PizzaBraz.Domain.Entities;
using PizzaBraz.Infra.Context;
using PizzaBraz.Infra.Interfaces;
namespace PizzaBraz.Infra.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        private readonly PizzaBrazContext _context;

        public UserRepository(PizzaBrazContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<User>> GetByCompanyId(Guid companyId)
        {
            return await _context.Users.Where(x => x.CompanyId == companyId).ToListAsync();
        }

        public async Task<User> GetByEmail(string email)
        {
            return await _context.Users.SingleOrDefaultAsync(x => x.Email == email);
        }

        public async Task<List<User>> SearchByEmail(string email)
        {
            var users = await _context.Users
                                 .Where(x => EF.Functions.Like(x.Email, $"%{email}%"))
                                 .AsNoTracking()
                                 .ToListAsync();
            return users;
        }

        public async Task<List<User>> SearchByName(string name)
        {
            var users = await _context.Users
                                 .Where(x => EF.Functions.Like(x.Name, $"%{name}%"))
                                 .AsNoTracking()
                                 .ToListAsync();
            return users;
        }
    }
}
