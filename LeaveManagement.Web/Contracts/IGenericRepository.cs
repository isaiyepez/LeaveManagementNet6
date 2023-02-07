namespace LeaveManagement.Web.Contracts
{
    public interface IGenericRepository<T> where T : class
    {   
        Task<IEnumerable<T>> GetAllAsync();
        Task<int> GetCountAsync();
        Task<T?> GetByIdAsync(int? id);
        Task<bool> ExistsAsync(int? id);
        Task<T> AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(int? id);

    }
}
