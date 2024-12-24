using UniversityAdmission.Domain.Class;

namespace UniversityAdmission.Domain.Repositories;

public class ApplicationRepository : IRepository<Application>
{
    private int _id = 0;
    private List<Application> _applications = [];

    public bool Delete(int id)
    {
        var exam = GetById(id);
        if (exam == null)
            return false;
        _applications.Remove(exam);
        return true;
    }

    public IEnumerable<Application> GetAll() => _applications;

    public Application? GetById(int id) => _applications.Find(e => e.IdApplication == id);

    public Application Post(Application entity)
    {
        entity.IdApplication = _id++;
        _applications.Add(entity);
        return entity;
    }

    public bool Put(int id, Application newEntity)
    {
        var oldEntity = GetById(id);
        if (oldEntity == null)
            return false;
        oldEntity.ApplicantId = newEntity.ApplicantId;
        oldEntity.SpecialtyId = newEntity.SpecialtyId;
        oldEntity.Priority = newEntity.Priority;
        return true;
    }
}
