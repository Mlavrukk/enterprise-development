using UniversityAdmission.Domain.Class;
using UniversityAdmission.Domain.Dto;
using UniversityAdmission.Domain.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace UniversityAdmission.Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class RequestController(IRepository<Applicant> repositoryApplicant, IRepository<Exam> repositoryExam, IRepository<ExamResult> repositoryExamResult, IRepository<Specialty> repositorySpecialty, IRepository<Application> repositoryApplication) : Controller
{
    /// <summary>
    /// Вывести информацию об абитуриентах из указанного города.
    /// По умолчанию выводится информация об абитуриентах из города "Самара"
    /// </summary>
    [HttpGet("applicant-by-city")]
    public ActionResult<IEnumerable<ApplicantDtoGet>> GetApplicantByCity(string сity = "Самара")
    {
        var request = (from applicant in repositoryApplicant.GetAll()
                       where applicant.City == сity
                       select applicant);
        return Ok(request);
    }

    /// <summary>
    /// Вывести информацию об абитуриентах старше ageLimit лет, упорядочить по ФИО.
    /// </summary>
    [HttpGet("applicant-older-ageLimit")]
    public ActionResult<IEnumerable<ApplicantDtoGet>> GetApplicantOlderValue(int ageLimit = 20)
    {
        DateOnly currentDate = DateOnly.FromDateTime(DateTime.Now); // Текущая дата

        var request = repositoryApplicant.GetAll()
            .Where(applicant =>
            {
                int age = currentDate.Year - applicant.DateOfBirth.Year;
                if ((currentDate.Month < applicant.DateOfBirth.Month) ||
                (currentDate.Month == applicant.DateOfBirth.Month && currentDate.Day < applicant.DateOfBirth.Day))
                {
                    age--;
                }

                return age > ageLimit;
            })
            .OrderBy(applicant => applicant.FullName);
        return Ok(request);
    }
    public class ApplicantDtoWithExamResult
    {
        public Applicant Applicant { get; set; }
        public double SumExamResult { get; set; }
    }
    /// <summary>
    /// Выводит информацию об абитуриентах, поступающих на указанную
    /// специальность(без учета приоритета), упорядочить по сумме баллов за
    /// экзамены.
    /// </summary>
    [HttpGet("applicant-by-speciality")]
    public ActionResult<IEnumerable<ApplicantDtoWithExamResult>> GetApplicantsBySpecialtySortedByExamScores(string specialtyCode = "10.05.03D")
    {
        var request = (from applicant in repositoryApplicant.GetAll()
                       join application in repositoryApplication.GetAll() on applicant.IdApplicant equals application.ApplicantId
                       join specialty in repositorySpecialty.GetAll() on application.SpecialtyId equals specialty.IdSpecialty
                       join examResult in repositoryExamResult.GetAll() on applicant.IdApplicant equals examResult.ApplicantId
                       where specialty.Code == specialtyCode
                       group examResult by new
                       {
                           Applicant = applicant,
                           SpecialtyName = specialty.Name
                       } into applicantGroup
                       let totalScore = applicantGroup.Sum(exam => exam.Score)
                       orderby totalScore descending
                       select new ApplicantDtoWithExamResult
                       {
                           Applicant = applicantGroup.Key.Applicant,
                           SumExamResult = totalScore
                       })
                       .ToList();
        return Ok(request);
    }

    public class ApplicantCountForSpecialityDto
    {
        public int SpecialtyId { get; set; }
        public string Code { get; set; }
        public int ApplicantCount { get; set; }
    }

    



}
