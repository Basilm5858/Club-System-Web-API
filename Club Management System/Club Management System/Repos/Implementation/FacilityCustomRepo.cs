using Club_Management_System.Data;
using Club_Management_System.DTOs;
using Club_Management_System.Models;
using Club_Management_System.Repos.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Club_Management_System.Repos.Implementation
{
    public class FacilityCustomRepo : GenericRepo<Facility>, IFacility
    {
        private readonly My_AppContext _context;

        public FacilityCustomRepo(My_AppContext context) : base(context)
        {
            _context = context;
        }

        public async Task<ICollection<FacilityDTO>> SortById()
        {
            return await _context.Facilities
                .OrderBy(x => x.Id)
                .Select(x => new FacilityDTO
                {
                    Id = x.Id,
                    Capacity = x.Capacity,
                    HourlyPrice = x.HourlyPrice,
                    Name = x.Name,
                }).ToListAsync();
        }
    }
}
