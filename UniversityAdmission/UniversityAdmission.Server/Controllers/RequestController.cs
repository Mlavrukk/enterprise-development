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
        public int ApplicantCount { get; set; }
    }

    /// <summary>
    /// Вывести информацию о количестве абитуриентов, поступающих на каждую
    /// специальность по первому приоритету.
    /// </summary>
    [HttpGet("applicant-count-by-speciality")]
    public ActionResult<IEnumerable<ApplicantCountForSpecialityDto>> GetCountApplicantToSpecialty()
    {
        var request = (from application in repositoryApplication.GetAll()
                       join specialty in repositorySpecialty.GetAll() on application.SpecialtyId equals specialty.IdSpecialty
                       where application.Priority == 0
                       group application by specialty.IdSpecialty into specialtyGroup
                       select new ApplicantCountForSpecialityDto
                       {
                           SpecialtyId = specialtyGroup.Key,
                           ApplicantCount = specialtyGroup.Count()
                       })
                       .ToList();
        return Ok(request);
    }

    public class TopFiveApplicantDto()
    {
        public Applicant Applicant { get; set; }
        public double TotalScore { get; set; }
    }
    /// <summary>
    /// Вывести информацию о топ 5 абитуриентах, набравших наибольшее число
    /// баллов за три предмета.
    /// </summary>
    /// <returns></returns>
    [HttpGet("top-five-applicant-by-score")]
    public ActionResult<IEnumerable<TopFiveApplicantDto>> GetTopFiveApplicantToScore()
    {
        var request = (from examResult in repositoryExamResult.GetAll()
                       join applicant in repositoryApplicant.GetAll() on examResult.ApplicantId equals applicant.IdApplicant
                       group examResult by applicant into applicantGroup
                       let totalScore = applicantGroup.Sum(result => result.Score)
                       orderby totalScore descending
                       select new TopFiveApplicantDto
                       {
                           Applicant = applicantGroup.Key,
                           TotalScore = totalScore
                       })
                       .Take(5)
                       .ToList();
        return Ok(request);
    }


    public class ApplicantWithMaxScoreWithSpecialty
    {
        public Applicant Applicant { get; set; }
        public double MaxScore { get; set; }
        public int SpecialtyId { get; set; }
    }

    /// <summary>
    /// Вывести информацию об абитуриентах(и их приоритетных
    /// специальностях), которые набрали максимальный балл по каждому из
    /// предметов.
    /// </summary>
    /// <returns></returns>
    [HttpGet("get-applicant-specialty-max-score")]
    public ActionResult<IEnumerable<ApplicantWithMaxScoreWithSpecialty>> GetApplicantAndSpecialtyMaxScore()
    {
        var request = (from examResult in repositoryExamResult.GetAll()
                       join applicant in repositoryApplicant.GetAll() on examResult.ApplicantId equals applicant.IdApplicant
                       join application in repositoryApplication.GetAll() on applicant.IdApplicant equals application.ApplicantId
                       join specialty in repositorySpecialty.GetAll() on application.SpecialtyId equals specialty.IdSpecialty
                       group examResult by examResult.ExamId into examGroup
                       let maxScore = examGroup.Max(result => result.Score)
                       select new ApplicantWithMaxScoreWithSpecialty
                       {
                           Applicant = (from result in examGroup
                                        where result.Score == maxScore
                                        join applicant in repositoryApplicant.GetAll() on result.ApplicantId equals applicant.IdApplicant
                                        select applicant).FirstOrDefault(),
                           MaxScore = maxScore,
                           SpecialtyId = (from result in examGroup
                                          where result.Score == maxScore
                                          join applicant in repositoryApplicant.GetAll() on result.ApplicantId equals applicant.IdApplicant
                                          join application in repositoryApplication.GetAll() on applicant.IdApplicant equals application.ApplicantId
                                          select application.SpecialtyId).FirstOrDefault()
                       })
                       .ToList();

        return Ok(request);
    }
}
