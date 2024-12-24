
namespace UniversityAdmission.WebApplication.Api
{
    public interface IApiWrapper
    {
        Task AddApplicant(ApplicantDto dto);
        Task AddExam(ExamDto dto);
        Task DeleteApplicant(int id);
        Task DeleteExam(int id);
        Task<ApplicantDto> GetApplicant(int id);
        Task<ICollection<ApplicantDtoGet>> GetApplicants();
        Task<ExamDto> GetExam(int id);
        Task<ICollection<ExamDtoGet>> GetExams();
        Task UpdateApplicant(int id, ApplicantDto dto);
        Task UpdateExam(int id, ExamDto dto);
    }
}