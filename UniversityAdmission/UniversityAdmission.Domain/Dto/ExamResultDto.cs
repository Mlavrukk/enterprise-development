﻿namespace UniversityAdmission.Domain.Dto;

public class ExamResultDto
{

    /// <summary>
    /// Идентификатор абитуриента
    /// </summary>
    public required int ApplicantId { get; set; }

    /// <summary>
    /// Идентификатор экзамена
    /// </summary>
    public required int ExamId { get; set; }

    /// <summary>
    /// Баллы абитуриента на экзамене
    /// </summary>
    public required double Score { get; set; }
}