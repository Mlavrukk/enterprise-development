using Microsoft.EntityFrameworkCore;
using UniversityAdmission.Domain.Class;

namespace UniversityAdmission.Domain.Repositories;

public class ExamResultRepository(UniversityAdmissionContext context) : IRepository<ExamResult>
{
    public async Task<bool> Delete(int id)
    {
        var examResult = await GetById(id);
        if (examResult == null)
            return false;
        context.ExamResults.Remove(examResult);
        await context.SaveChangesAsync();
        return true;
    }

    public async Task<List<ExamResult>> GetAll() => await context.ExamResults.ToListAsync();

    public async Task<ExamResult?> GetById(int id) => await context.ExamResults.FirstOrDefaultAsync(e => e.IdExamResult == id);

    public async Task<ExamResult> Post(ExamResult entity)
    {
        await context.ExamResults.AddAsync(entity);
        await context.SaveChangesAsync();
        return entity;
    }

    public async Task<bool> Put(int id, ExamResult newEntity)
    {
        var oldEntity = await GetById(id);
        if (oldEntity == null)
            return false;
        oldEntity.ApplicantId = newEntity.ApplicantId;
        oldEntity.ExamId = newEntity.ExamId;
        oldEntity.Score = newEntity.Score;
        await context.SaveChangesAsync();
        return true;
    }
}
