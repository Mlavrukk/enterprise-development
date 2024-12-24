using UniversityAdmission.Domain.Class;

namespace UniversityAdmission.Domain.Dto.DtoForRequest;

public class ApplicantWithMaxScoreWithSpecialty
{
    public Applicant Applicant { get; set; }
    public double MaxScore { get; set; }
    public int SpecialtyId { get; set; }
}
