using Club_Management_System.Data;
using Club_Management_System.Models;
using Club_Management_System.Repos.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Club_Management_System.Repos.Implementation
{
    public class AuthRepoCustomRepo : GenericRepo<User>, IAuthRepo
    {
        private readonly My_AppContext _context;
        public AuthRepoCustomRepo(My_AppContext context) : base(context)
        {
            _context = context;
        }

        public async Task<User?> GetUserByUserName(string name)
        {
            return await _context.Users.FirstOrDefaultAsync(x => x.UserName == name);
        }
    }
}
