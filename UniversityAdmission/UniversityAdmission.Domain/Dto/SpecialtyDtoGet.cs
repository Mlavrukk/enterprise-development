namespace UniversityAdmission.Domain.Dto;

public class SpecialtyDtoGet
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
