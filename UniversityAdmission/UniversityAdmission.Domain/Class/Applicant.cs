using System.ComponentModel.DataAnnotations;

namespace UniversityAdmission.Domain.Class;

/// <summary>
/// Абитуриент
/// </summary>
public class Applicant
{
    /// <summary>
    /// Идентификатор абитуриента
    /// </summary>
    [Key]
    public required int IdApplicant { get; set; }

    /// <summary>
    /// ФИО абитуриента
    /// </summary>
    public required string FullName { get; set; }

    /// <summary>
    /// Дата рождения абитуриента
    /// </summary>
    public required DateOnly DateOfBirth { get; set; }

    /// <summary>
    /// Страна абитуриента
    /// </summary>
    public required string Country { get; set; }

    /// <summary>
    /// Город абитуриента
    /// </summary>
    public required string City { get; set; }
}