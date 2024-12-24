namespace UniversityAdmission.Domain.Class;

/// <summary>
/// Экзамен
/// </summary>
public class Exam
{
    /// <summary>
    /// Идентификатор экзамена
    /// </summary>
    public required int IdExam { get; set; }

    /// <summary>
    /// Название экзамена
    /// </summary>
    public required string Name { get; set; }
}