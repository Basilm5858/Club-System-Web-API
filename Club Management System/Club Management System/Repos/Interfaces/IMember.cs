using Club_Management_System.DTOs;
using Club_Management_System.Models;

namespace Club_Management_System.Repos.Interfaces
{
    public interface IMember : IGenericRepo<Member>
    {
        Task<ICollection<MemberDTO>> GetMemberspPaginationAsync(int pageno, int size);
        Task<ICollection<MemberDTO>> SearchMemberspAsyncByName(string name);
    }
}
