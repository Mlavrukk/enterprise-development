using UniversityAdmission.Domain.Class;

namespace UniversityAdmission.Domain.Dto.DtoForRequest;

public class TopFiveApplicantDto()
{
    public Applicant Applicant { get; set; }
    public double TotalScore { get; set; }
}
