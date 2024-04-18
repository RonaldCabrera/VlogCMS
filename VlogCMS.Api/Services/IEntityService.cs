namespace VlogCMS.Api.Services
{
    public interface IEntityService<T>
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        Task UpsertAsync(T entity);
        Task RemoveByIdAsync(int id);
    }
}
