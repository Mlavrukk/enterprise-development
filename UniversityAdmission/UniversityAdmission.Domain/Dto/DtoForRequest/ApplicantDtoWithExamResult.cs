using UniversityAdmission.Domain.Class;

namespace UniversityAdmission.Domain.Dto.DtoForRequest;
/// <summary>
/// Класс для удобного предоставления данных для запроса: 
/// Вывести информацию об абитуриентах, поступающих на указанную
/// специальность(без учета приоритета), упорядочить по сумме баллов за экзамены.
/// </summary>
public class ApplicantDtoWithExamResult
{
    /// <summary>
    /// Класс представляющий абитуриента
    /// </summary>
    public Applicant Applicant { get; set; }
    /// <summary>
    /// Сумма баллов за экзамены
    /// </summary>
    public double SumExamResult { get; set; }
}