using Microsoft.EntityFrameworkCore;
using UniversityAdmission.Domain.Class;

namespace UniversityAdmission.Domain.Repositories;

public class ApplicationRepository(UniversityAdmissionContext context) : IRepository<Application>
{
    public async Task<bool> Delete(int id)
    {
        var application = await GetById(id);
        if (application == null)
            return false;
        context.Applications.Remove(application);
        await context.SaveChangesAsync();
        return true;
    }

    public async Task<List<Application>> GetAll() => await context.Applications.ToListAsync();

    public async Task<Application?> GetById(int id) => await context.Applications.FirstOrDefaultAsync(a => a.i == id);

    public async Task<Application> Post(Application entity)
    {
        await context.Applications.AddAsync(entity);
        await context.SaveChangesAsync();
        return entity;
    }

    public async Task<bool> Put(int id, Application newEntity)
    {
        var oldEntity = await GetById(id);
        if (oldEntity == null)
            return false;
        oldEntity.Priority = newEntity.Priority;
        oldEntity.ApplicantId = newEntity.ApplicantId;
        oldEntity.SpecialtyId = newEntity.SpecialtyId;
        await context.SaveChangesAsync();
        return true;
    }
}