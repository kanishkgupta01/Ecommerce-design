using Ecom_RajasthanRoyals.Data;
using Ecom_RajasthanRoyals.DTOs;
using Ecom_RajasthanRoyals.Models.SQL;
using Microsoft.EntityFrameworkCore;

namespace Ecom_RajasthanRoyals.Services
{
    public class UserService
    {
        private readonly RRSQLDBContext _context;

        public UserService(RRSQLDBContext context)
        {
            _context = context;
        }

        public async Task<User> RegisterAsync(RegisterUserDto dto)
        {
            var user = new User
            {
                UserName = dto.UserName,
                Email = dto.Email,
                Password = dto.Password
            };
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<User> LoginAsync(string email, string password) =>
            await _context.Users.FirstOrDefaultAsync(u => u.Email == email && u.Password == password);

        public async Task<List<User>> GetAllUsersAsync() =>
            await _context.Users.Include(u => u.Addresses).ToListAsync();
    }
}
