using Club_Management_System.Data;
using Club_Management_System.DTOs;
using Club_Management_System.Models;
using Club_Management_System.Repos.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Club_Management_System.Repos.Implementation
{
    public class MemberCustomRepo : GenericRepo<Member>, IMember
    {
        private readonly My_AppContext _context;
        public MemberCustomRepo(My_AppContext context) : base(context)
        {
            _context = context;
        }

        public async Task<ICollection<MemberDTO>> GetMemberspPaginationAsync(int pageno, int size)
        {
            return await _context.Members
                .Include(x => x.Membership)
                .OrderBy(x => x.Id)
                .Skip((pageno - 1) * size)
                .Take(size)
                .Select(x => new MemberDTO
                {
                    BirthDate = x.BirthDate,
                    Email = x.Email,
                    FullName = x.FullName,
                    Membership = x.Membership,
                    Id = x.Id,
                    Phone = x.Phone
                })
                .ToListAsync();
        }

        public async Task<ICollection<MemberDTO>> SearchMemberspAsyncByName(string name)
        {
            return await _context.Members
                .Include(x => x.Membership)
                .Where(x => x.FullName.Contains(name))
                .Select(x => new MemberDTO
                {
                    BirthDate = x.BirthDate,
                    Email = x.Email,
                    FullName = x.FullName,
                    Membership = x.Membership,
                    Id = x.Id,
                    Phone = x.Phone
                })
                .ToListAsync();
        }
    }
}
