using UniversityAdmission.Domain.Class;

namespace UniversityAdmission.Domain.Repositories;

public class SpecialtyRepository : IRepository<Specialty>
{
    private int _id = 0;
    private List<Specialty> _specialtys = [];

    public bool Delete(int id)
    {
        var specialty = GetById(id);
        if (specialty == null)
        {
            return false;
        }
        _specialtys.Remove(specialty);
        return true;
    }

    public IEnumerable<Specialty> GetAll() => _specialtys;

    public Specialty? GetById(int id) => _specialtys.Find(a => a.IdSpecialty == id);

    public Specialty Post(Specialty entity)
    {
        entity.IdSpecialty = _id++;
        _specialtys.Add(entity);
        return entity;
    }

    public bool Put(int id, Specialty newEntity)
    {
        var oldEntity = GetById(id);
        if (oldEntity == null)
        {
            return false;
        }
        oldEntity.Code = newEntity.Code;
        oldEntity.Name = newEntity.Name;
        oldEntity.Faculty = newEntity.Faculty;
        return true;
    }

}
