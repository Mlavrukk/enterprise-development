using UniversityAdmission.Domain.Class;

namespace UniversityAdmission.Domain.Dto.DtoForRequest;

public class ApplicantDtoWithExamResult
{
    public Applicant Applicant { get; set; }
    public double SumExamResult { get; set; }
}