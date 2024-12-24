using UniversityAdmission.Domain.Class;
using UniversityAdmission.Domain.Dto;
using UniversityAdmission.Domain.Dto.DtoForRequest;
using UniversityAdmission.Domain.Repositories;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using UniversityAdmission.Server.Servicies;

namespace UniversityAdmission.Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class RequestController(IRepository<Applicant> repositoryApplicant, IRepository<ExamResult> repositoryExamResult, IRepository<Specialty> repositorySpecialty, IRepository<Application> repositoryApplication, IMapper mapper, IAnalayzerService AnalayzerService) : ControllerBase
{
    /// <summary>
    /// Вывести информацию об абитуриентах из указанного города.
    /// По умолчанию выводится информация об абитуриентах из города "Самара"
    /// </summary>
    [HttpGet("applicant-by-city")]
    public ActionResult<IEnumerable<ApplicantDtoGet>> GetApplicantByCity(string сity = "Самара")
    {
        var request = AnalayzerService.GetApplicantByCity(сity);
        return Ok(request);
    }

    /// <summary>
    /// Вывести информацию об абитуриентах старше ageLimit лет, упорядочить по ФИО.
    /// </summary>
    [HttpGet("applicant-older-ageLimit")]
    public ActionResult<IEnumerable<ApplicantDtoGet>> GetApplicantOlderValue(int ageLimit = 20)
    {
        var request = AnalayzerService.GetApplicantOlderValue(ageLimit);
        return Ok();
    }

    /// <summary>
    /// Выводит информацию об абитуриентах, поступающих на указанную
    /// специальность(без учета приоритета), упорядочить по сумме баллов за
    /// экзамены.
    /// </summary>
    [HttpGet("applicant-by-speciality")]
    public ActionResult<IEnumerable<ApplicantDtoWithExamResult>> GetApplicantsBySpecialtySortedByExamScores(string specialtyCode = "10.05.03D")
    {
        var request = AnalayzerService.GetApplicantsBySpecialtySortedByExamScores(specialtyCode);
        return Ok(request);
    }

    /// <summary>
    /// Вывести информацию о количестве абитуриентов, поступающих на каждую
    /// специальность по первому приоритету.
    /// </summary>
    [HttpGet("applicant-count-by-speciality")]
    public ActionResult<IEnumerable<ApplicantCountForSpecialityDto>> GetCountApplicantToSpecialty()
    {
        var request = AnalayzerService.GetCountApplicantToSpecialty();
        return Ok(request);
    }

    /// <summary>
    /// Вывести информацию о топ 5 абитуриентах, набравших наибольшее число
    /// баллов за три предмета.
    /// </summary>
    /// <returns></returns>
    [HttpGet("top-five-applicant-by-score")]
    public ActionResult<IEnumerable<TopFiveApplicantDto>> GetTopFiveApplicantToScore()
    {
        var request = AnalayzerService.GetTopFiveApplicantToScore();
        return Ok(request);
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
        var request = AnalayzerService.GetApplicantAndSpecialtyMaxScore();

        return Ok(request);
    }
}
