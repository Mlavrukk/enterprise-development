namespace UniversityAdmission.Domain.Dto;
/// <summary>
/// Класс Заявление Dto 
/// Данное Dto скрывает реализацию свойства ApplicationId
/// дабы сделегировать назначение Id серверу,
/// и убрать возможность менять Id уже созданной сущности
/// </summary>
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
