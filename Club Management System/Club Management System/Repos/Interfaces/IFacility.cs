using Club_Management_System.DTOs;
using Club_Management_System.Models;

namespace Club_Management_System.Repos.Interfaces
{
    public interface IFacility : IGenericRepo<Facility>
    {
        Task<ICollection<FacilityDTO>> SortById();
    }
}
