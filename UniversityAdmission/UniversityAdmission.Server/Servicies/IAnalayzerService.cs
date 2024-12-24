using UniversityAdmission.Domain.Dto;
using UniversityAdmission.Domain.Dto.DtoForRequest;

namespace UniversityAdmission.Server.Servicies
{
    public interface IAnalayzerService
    {
        IEnumerable<ApplicantWithMaxScoreWithSpecialty> GetApplicantAndSpecialtyMaxScore();
        IEnumerable<ApplicantDtoGet> GetApplicantByCity(string city);
        IEnumerable<ApplicantDtoGet> GetApplicantOlderValue(int ageLimit);
        IEnumerable<ApplicantDtoWithExamResult> GetApplicantsBySpecialtySortedByExamScores(string specialtyCode);
        IEnumerable<ApplicantCountForSpecialityDto> GetCountApplicantToSpecialty();
        IEnumerable<TopFiveApplicantDto> GetTopFiveApplicantToScore();
    }
}