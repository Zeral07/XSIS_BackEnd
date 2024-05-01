namespace XSISDataAccess.Interface
{
    public interface IRepository<T> where T : class
    {
        Task<T> Create(T entity);
        Task<T> Update(T entity);
        Task Delete(int id);
        Task<List<T>> GetAll();
        Task<T?> GetByID(int id);
    }
}
