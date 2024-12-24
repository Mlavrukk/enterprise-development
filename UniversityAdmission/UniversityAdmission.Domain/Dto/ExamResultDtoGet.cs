namespace UniversityAdmission.Domain.Dto;
/// <summary>
/// Класс Результат за Экзамен(ExamResult) Dto. 
/// Соданный для передачи информации между слоями приложения 
/// В нашем слуаче Dto совпадает с классом ExamResult.
/// </summary>
public class ExamResultDtoGet
{
    /// <summary>
    /// Идентификатор результата
    /// </summary>
    public required int IdExamResult { get; set; }

    /// <summary>
    /// Идентификатор абитуриента
    /// </summary>
    public required int ApplicantId { get; set; }

    /// <summary>
    /// Идентификатор экзамена
    /// </summary>
    public required int ExamId { get; set; }

    /// <summary>
    /// Баллы абитуриента на экзамене
    /// </summary>
    public required double Score { get; set; }
}
