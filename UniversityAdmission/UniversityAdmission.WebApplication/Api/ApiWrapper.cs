namespace UniversityAdmission.WebApplication.Api;

public class ApiWrapper(IConfiguration configuration) : IApiWrapper
{
    public ApiClient Client = new ApiClient(configuration["ApiUrl"], new());

    public async Task<ICollection<ApplicantDtoGet>> GetApplicants() => await Client.ApplicantAllAsync();
    public async Task<ApplicantDto> GetApplicant(int id) => await Client.ApplicantGETAsync(id);
    public async Task UpdateApplicant(int id, ApplicantDto dto) => await Client.ApplicantPUTAsync(id, dto);
    public async Task DeleteApplicant(int id) => await Client.ApplicantDELETEAsync(id);
    public async Task AddApplicant(ApplicantDto dto) => await Client.ApplicantPOSTAsync(dto);

    public async Task<ICollection<ExamDtoGet>> GetExams() => await Client.ExamAllAsync();
    public async Task<ExamDto> GetExam(int id) => await Client.ExamGETAsync(id);
    public async Task UpdateExam(int id, ExamDto dto) => await Client.ExamPUTAsync(id, dto);
    public async Task DeleteExam(int id) => await Client.ExamDELETEAsync(id);
    public async Task AddExam(ExamDto dto) => await Client.ExamPOSTAsync(dto);
}
