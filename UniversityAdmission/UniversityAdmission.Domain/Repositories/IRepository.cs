namespace UniversityAdmission.Domain.Repositories;
public interface IRepository<T>
{
    /// <summary>
    /// Возвращает коллекцию сущностей
    /// </summary>
    /// <returns></returns>
    public IEnumerable<T> GetAll();
    /// <summary>
    /// Возвращает сущность по указанному id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public T? GetById(int id);
    /// <summary>
    /// Добавляет сущность в репозиторий
    /// </summary>
    /// <param name="entity"></param>
    /// <returns></returns>
    public T Post(T entity);
    /// <summary>
    /// Изменяет поля сущности по указанному id
    /// </summary>
    /// <param name="id"></param>
    /// <param name="entity"></param>
    /// <returns></returns>
    public bool Put(int id, T entity);
    /// <summary>
    /// Удаляет сущность из репозитория по указанному id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public bool Delete(int id);
}
