namespace UniversityAdmission.Domain.Dto;

/// <summary>
/// Класс абитуриент Dto. 
/// Соданный для передачи информации между слоями приложения 
/// В нашем слуаче Dto совпадает с классом Applicant.
/// </summary>
public class ApplicantDtoGet
{
    /// <summary>
    /// Идентификатор абитуриента
    /// </summary>
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
