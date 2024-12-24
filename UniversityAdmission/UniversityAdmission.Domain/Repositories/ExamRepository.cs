using Microsoft.EntityFrameworkCore;
using UniversityAdmission.Domain.Class;

namespace UniversityAdmission.Domain.Repositories;

public class ExamRepository(UniversityAdmissionContext context) : IRepository<Exam>
{
    public async Task<bool> Delete(int id)
    {
        var exam = await GetById(id);
        if (exam == null)
            return false;
        context.Exams.Remove(exam);
        await context.SaveChangesAsync();
        return true;
    }

    public async Task<List<Exam>> GetAll() => await context.Exams.ToListAsync();

    public async Task<Exam?> GetById(int id) => await context.Exams.FirstOrDefaultAsync(e => e.Id == id);

    public async Task<Exam> Post(Exam entity)
    {
        await context.Exams.AddAsync(entity);
        await context.SaveChangesAsync();
        return entity;
    }

    public async Task<bool> Put(int id, Exam newEntity)
    {
        var oldEntity = await GetById(id);
        if (oldEntity == null)
            return false;
        oldEntity.Name = newEntity.Name;
        await context.SaveChangesAsync();
        return true;
    }
}