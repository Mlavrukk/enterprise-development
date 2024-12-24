using UniversityAdmission.Domain.Class;

namespace UniversityAdmission.Domain.Dto.DtoForRequest;
/// <summary>
/// Класс для удобного представления данных для запроса:
/// Вывести информацию о топ 5 абитуриентах, набравших наибольшее число
/// баллов за три предмета.
/// </summary>
public class TopFiveApplicantDto()
{
    /// <summary>
    /// Класс представляющий Абитуриента
    /// </summary>
    public Applicant Applicant { get; set; }
    /// <summary>
    /// Кол-во баллов за экзамен
    /// </summary>
    public double TotalScore { get; set; }
}
