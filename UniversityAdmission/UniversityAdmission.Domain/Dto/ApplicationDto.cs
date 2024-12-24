namespace UniversityAdmission.Domain.Dto;

public class ApplicationDto
{
    /// <summary>
    /// Идентификатор абитуриента
    /// </summary>
    public required int ApplicantId { get; set; }

    /// <summary>
    /// Идентификатор специальности
    /// </summary>
    public required int SpecialtyId { get; set; }

    /// <summary>
    /// Приоритет специальности
    /// </summary>
    public required int Priority { get; set; }
}
