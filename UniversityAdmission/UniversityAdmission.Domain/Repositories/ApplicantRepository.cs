using UniversityAdmission.Domain.Class;
using UniversityAdmission.Domain;
using Microsoft.EntityFrameworkCore;
namespace UniversityAdmission.Domain.Repositories;

public class ApplicantRepository(UniversityAdmissionContext context) : IRepository<Applicant>
{
    public async Task<bool> Delete(int id)
    {
        var applicant = await GetById(id);
        if(applicant == null)
            return false;
        context.Applicants.Remove(applicant);
        await context.SaveChangesAsync();
        return true;
    }

    public async Task<List<Applicant>> GetAll() => await context.Applicants.ToListAsync();

    public async Task<Applicant?> GetById(int id) => await context.Applicants.FirstOrDefaultAsync(a => a.IdApplicant == id);

    public async Task<Applicant> Post(Applicant entity)
    {
        await context.Applicants.AddAsync(entity);
        await context.SaveChangesAsync();
        return entity;
    }

    public async Task<bool> Put(int id, Applicant newEntity)
    {
        var oldEntity = await GetById(id);
        if (oldEntity == null)
            return false;
        oldEntity.DateOfBirth = newEntity.DateOfBirth;
        oldEntity.FullName = newEntity.FullName;
        oldEntity.Country = newEntity.Country;
        oldEntity.City = newEntity.City;
        await context.SaveChangesAsync();
        return true;
    }
}
