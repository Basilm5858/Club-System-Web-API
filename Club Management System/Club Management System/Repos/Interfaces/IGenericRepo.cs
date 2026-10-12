namespace Club_Management_System.Repos.Interfaces
{
    public interface IGenericRepo<T> where T : class
    {
        Task<ICollection<T>> GetAll();
        Task<T?> GetById(int id);
        Task AddAsync(T item);
        void Delete(T item);
    }
}
