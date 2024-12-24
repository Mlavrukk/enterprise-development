namespace UniversityAdmission.Domain.Dto;
/// <summary>
/// Класс Exam(Экзамен) Dto 
/// Данное Dto скрывает реализацию свойства ExamId
/// дабы сделегировать назначение Id серверу,
/// и убрать возможность менять Id уже созданной сущности
/// </summary>
public class ExamDto
{
    /// <summary>
    /// Название экзамена
    /// </summary>
    public required string Name { get; set; }
}
