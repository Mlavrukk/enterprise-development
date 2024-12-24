using UniversityAdmission.Domain.Class;

namespace UniversityAdmission.Domain.Repositories;

public class ExamRepository :IRepository<Exam>
{
    private int _id = 0;
    private List<Exam> _exams = [];

    public bool Delete(int id)
    {
        var exam = GetById(id);
        if (exam == null)
            return false;
        _exams.Remove(exam);
        return true;
    }

    public IEnumerable<Exam> GetAll() => _exams;

    public Exam? GetById(int id) => _exams.Find(e => e.IdExam == id);

    public Exam Post(Exam entity)
    {
        entity.IdExam = _id++;
        _exams.Add(entity);
        return entity;
    }

    public bool Put(int id, Exam newEntity)
    {
        var oldEntity = GetById(id);
        if (oldEntity == null)
            return false;
        oldEntity.Name = newEntity.Name;
        return true;
    }
}
