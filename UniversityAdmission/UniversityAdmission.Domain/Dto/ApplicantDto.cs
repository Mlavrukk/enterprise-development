namespace UniversityAdmission.Domain.Dto;
/// <summary>
/// Класс Абитуриет Dto 
/// Данное Dto скрывает реализацию свойства AplicantId
/// дабы сделегировать назначение Id серверу,
/// и убрать возможность менять Id уже созданной сущности
/// </summary>
public class ApplicantDto
{

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
