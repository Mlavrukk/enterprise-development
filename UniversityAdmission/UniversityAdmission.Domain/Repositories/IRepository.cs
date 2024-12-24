namespace UniversityAdmission.Domain.Repositories;
public interface IRepository<T>
{
    public Task<List<T>> GetAll();
    public Task<T>? GetById(int id);
    public Task<T> Post(T entity);
    public Task<bool> Put(int id, T entity);
    public Task<bool> Delete(int id);
}
