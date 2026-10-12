using Club_Management_System.Models;

namespace Club_Management_System.Repos.Interfaces
{
    public interface IAuthRepo : IGenericRepo<User>
    {
        Task<User?> GetUserByUserName(string name);
    }
}
