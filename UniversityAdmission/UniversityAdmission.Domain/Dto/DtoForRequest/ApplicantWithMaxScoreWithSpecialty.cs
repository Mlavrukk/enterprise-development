using UniversityAdmission.Domain.Class;

namespace UniversityAdmission.Domain.Dto.DtoForRequest;
/// <summary>
/// Класс для удобного предоставления данных для запроса:
/// Вывести информацию об абитуриентах(и их приоритетных
/// специальностях), которые набрали максимальный балл по каждому из
/// предметов.
/// </summary>
public class ApplicantWithMaxScoreWithSpecialty
{
    /// <summary>
    /// Класс представляющий Абитуриента
    /// </summary>
    public Applicant Applicant { get; set; }
    /// <summary>
    /// Максимальное кол-во баллов
    /// </summary>
    public double MaxScore { get; set; }
    /// <summary>
    ///  Индификатор Специальности
    /// </summary>
    public int SpecialtyId { get; set; }
}
