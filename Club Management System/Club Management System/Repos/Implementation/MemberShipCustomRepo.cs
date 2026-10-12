using Club_Management_System.Data;
using Club_Management_System.DTOs;
using Club_Management_System.Models;
using Club_Management_System.Repos.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Club_Management_System.Repos.Implementation
{
    public class MemberShipCustomRepo : GenericRepo<Membership>, IMemberShip
    {
        private readonly My_AppContext _context;
        public MemberShipCustomRepo(My_AppContext context) : base(context)
        {
            _context = context;
        }

        public async Task<ICollection<MembershipDTO>> GetMembersActiveAsync()
        {
            return await _context.Memberships
                .Include(x => x.Member)
                .Where(x => x.Status == "Active")
                .Select(x => new MembershipDTO
                {
                    Status = x.Status,
                    StartDate = x.StartDate,
                    EndDate = x.EndDate,
                    Id = x.Id,
                    MemberId = x.MemberId,
                    Price = x.Price,
                    Type = x.Type,
                }).ToListAsync();
        }
    }
}
