using System.ComponentModel.DataAnnotations;

namespace UniversityAdmission.Domain.Class;

/// <summary>
/// Результат экзамена абитуриента
/// </summary>
public class ExamResult
{
    /// <summary>
    /// Идентификатор результата
    /// </summary>
    [Key]
    public required int IdExamResult { get; set; }

    /// <summary>
    /// Идентификатор абитуриента
    /// </summary>
    public required int ApplicantId { get; set; }

    /// <summary>
    /// Идентификатор экзамена
    /// </summary>
    public required int ExamId  { get; set; }

    /// <summary>
    /// Баллы абитуриента на экзамене
    /// </summary>
    public required double Score { get; set; }
}