using Microsoft.EntityFrameworkCore;
using UniversityAdmission.Domain.Class;

namespace UniversityAdmission.Domain.Repositories;

public class SpecialtyRepository(UniversityAdmissionContext context) : IRepository<Specialty>
{
    public async Task<bool> Delete(int id)
    {
        var specialty = await GetById(id);
        if (specialty == null)
            return false;
        context.Specialties.Remove(specialty);
        await context.SaveChangesAsync();
        return true;
    }

    public async Task<List<Specialty>> GetAll() => await context.Specialties.ToListAsync();

    public async Task<Specialty?> GetById(int id) => await context.Specialties.FirstOrDefaultAsync(a => a.IdSpecialty == id);

    public async Task<Specialty> Post(Specialty entity)
    {
        await context.Specialties.AddAsync(entity);
        await context.SaveChangesAsync();
        return entity;
    }

    public async Task<bool> Put(int id, Specialty newEntity)
    {
        var oldEntity = await GetById(id);
        if (oldEntity == null)
            return false;
        oldEntity.Code = newEntity.Code;
        oldEntity.Name = newEntity.Name;    
        oldEntity.Faculty = newEntity.Faculty;
        await context.SaveChangesAsync();
        return true;
    }
}
