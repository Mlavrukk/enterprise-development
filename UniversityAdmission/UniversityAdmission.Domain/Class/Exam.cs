using System.ComponentModel.DataAnnotations;

namespace UniversityAdmission.Domain.Class;

/// <summary>
/// Экзамен
/// </summary>
public class Exam
{
    /// <summary>
    /// Идентификатор экзамена
    /// </summary>
    [Key]
    public required int Id { get; set; }

    /// <summary>
    /// Название экзамена
    /// </summary>
    public required string Name { get; set; }
}