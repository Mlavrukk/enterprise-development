namespace UniversityAdmission.Domain.Dto;

/// <summary>
/// Класс Exam(Экзамен) Dto. 
/// Соданный для передачи информации между слоями приложения 
/// В нашем слуаче DtoGet совпадает с классом Exam.
/// </summary>
public class ExamDtoGet
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
