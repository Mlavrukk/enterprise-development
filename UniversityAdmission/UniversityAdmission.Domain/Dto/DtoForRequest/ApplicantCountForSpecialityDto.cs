namespace UniversityAdmission.Domain.Dto.DtoForRequest;

/// <summary>
/// Класс для удобства предоставления данных для запроса:
/// Вывести информацию о количестве абитуриентов, поступающих на каждую
/// специальность по первому приоритету.
/// </summary>
public class ApplicantCountForSpecialityDto
{
    /// <summary>
    /// Индификатор специальности
    /// </summary>
    public int SpecialtyId { get; set; }
    /// <summary>
    /// Кол-во абитуриентов на специальность
    /// </summary>
    public int ApplicantCount { get; set; }
}