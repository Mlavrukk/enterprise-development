using UniversityAdmission.Domain.Class;

namespace UniversityAdmission.Domain.Repositories;

public class ExamResultRepository : IRepository<ExamResult>
{
    private int _id = 0;
    private List<ExamResult> _examResults = [];

    public bool Delete(int id)
    {
        var examResult = GetById(id);
        if (examResult == null)
            return false;
        _examResults.Remove(examResult);
        return true;
    }

    public IEnumerable<ExamResult> GetAll() => _examResults;

    public ExamResult? GetById(int id) => _examResults.Find(e => e.IdExamResult == id);

    public ExamResult Post(ExamResult entity)
    {
        entity.IdExamResult = _id++;
        _examResults.Add(entity);
        return entity;
    }

    public bool Put(int id, ExamResult newEntity)
    {
        var oldEntity = GetById(id);
        if (oldEntity == null)
            return false;
        oldEntity.ApplicantId = newEntity.ApplicantId;
        oldEntity.ExamId = newEntity.ExamId;
        oldEntity.Score = newEntity.Score;
        return true;
    }
}
