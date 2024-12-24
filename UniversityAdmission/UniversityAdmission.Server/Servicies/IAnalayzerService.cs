using UniversityAdmission.Domain.Dto;
using UniversityAdmission.Domain.Dto.DtoForRequest;

namespace UniversityAdmission.Server.Servicies
{
    public interface IAnalayzerService
    {
        Task<IEnumerable<ApplicantWithMaxScoreWithSpecialty>> GetApplicantAndSpecialtyMaxScore();
        Task<IEnumerable<ApplicantDtoGet>> GetApplicantByCity(string city);
        Task<IEnumerable<ApplicantDtoGet>> GetApplicantOlderValue(int ageLimit);
        Task<IEnumerable<ApplicantDtoWithExamResult>> GetApplicantsBySpecialtySortedByExamScores(string specialtyCode);
        Task<IEnumerable<ApplicantCountForSpecialityDto>> GetCountApplicantToSpecialty();
        Task<IEnumerable<TopFiveApplicantDto>> GetTopFiveApplicantToScore();
    }
}