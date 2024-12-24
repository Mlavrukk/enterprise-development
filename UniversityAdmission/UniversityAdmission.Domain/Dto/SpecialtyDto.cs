namespace UniversityAdmission.Domain.Dto;
/// <summary>
/// Класс Специальность Dto 
/// Данное Dto скрывает реализацию свойства IdSpecialty
/// дабы делегировать назначение Id серверу,
/// и убрать возможность менять Id уже созданной сущности
/// </summary>
public class SpecialtyDto
{
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
