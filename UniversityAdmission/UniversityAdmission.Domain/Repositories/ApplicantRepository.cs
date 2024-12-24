using UniversityAdmission.Domain.Class;

namespace UniversityAdmission.Domain.Repositories;

public class ApplicantRepository : IRepository<Applicant>
{
    private int _id = 0;
    private List<Applicant> _applicants = [];

    public bool Delete(int id)
    {
        var applicant = GetById(id);
        if (applicant == null)
            return false;
        _applicants.Remove(applicant);
        return true;
    }

    public IEnumerable<Applicant> GetAll() => _applicants;

    public Applicant? GetById(int id) => _applicants.Find(a => a.IdApplicant == id);

    public Applicant Post(Applicant entity)
    {
        entity.IdApplicant = _id++;
        _applicants.Add(entity);
        return entity;
    }

    public bool Put(int id, Applicant newEntity)
    {
        var oldEntity = GetById(id);
        if (oldEntity == null)
            return false;
        oldEntity.DateOfBirth = newEntity.DateOfBirth;
        oldEntity.FullName = newEntity.FullName;
        oldEntity.Country = newEntity.Country;
        oldEntity.City = newEntity.City;
        return true;
    }
}
