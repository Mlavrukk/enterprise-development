namespace UniversityAdmission.Domain.Class;

/// <summary>
/// Специальность
/// </summary>
public class Specialty
{
    /// <summary>
    /// Идентификатор специальности
    /// </summary>
    public required int IdSpecialty { get; set; }
    /// <summary>
    /// Шифр специальности
    /// </summary>
    public required string Code { get; set; }

    /// <summary>
    /// Название специальности
    /// </summary>
    public required string Name { get; set; }

    /// <summary>
    /// Факультет
    /// </summary>
    public required string Faculty { get; set; }
}