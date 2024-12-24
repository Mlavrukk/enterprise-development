namespace UniversityAdmission.Domain.Dto;
/// <summary>
/// Класс Результат за экзамен(ExamResult) Dto 
/// Данное Dto скрывает реализацию свойства ExamResultId
/// дабы делегировать назначение Id серверу,
/// и убрать возможность менять Id уже созданной сущности
/// </summary>
public class ExamResultDto
{
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
