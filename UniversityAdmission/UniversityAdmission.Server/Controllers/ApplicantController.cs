using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using UniversityAdmission.Domain.Class;
using UniversityAdmission.Domain.Dto;
using UniversityAdmission.Domain.Repositories;

namespace UniversityAdmission.Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ApplicantController(IRepository<Applicant> repositoryApplicant, IRepository<ExamResult> repositoryExamResult, IRepository<Application> repositoryApplication, IMapper mapper) : Controller
{
    /// <summary>
    /// Получает список Абитуриентов из репозитория, в формате DtoGet
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public ActionResult<IEnumerable<ApplicantDtoGet>> Get()
    {
        return Ok(mapper.Map<IEnumerable<ApplicantDtoGet>>(repositoryApplicant.GetAll()));
    }

    /// <summary>
    /// Получает Абитуриента из репозитория по id, в формате Dto
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("{id}")]
    public ActionResult<ApplicantDto> Get(int id)
    {
        var applicant = repositoryApplicant.GetById(id);
        if (applicant == null) 
            return NotFound();
        return Ok(mapper.Map<ApplicantDto>(applicant));
    }

    /// <summary>
    /// Добавляет Абитуриента в репозиторий
    /// </summary>
    /// <param name="entity">добавляемая сущность в формате Dto</param>
    /// <returns></returns>
    [HttpPost]
    public IActionResult Post([FromBody] ApplicantDto entity)
    {
        repositoryApplicant.Post(mapper.Map<Applicant>(entity));
        return Ok();
    }

    /// <summary>
    /// Изменяем поля Абитуриента по id
    /// </summary>
    /// <param name="id"></param>
    /// <param name="entity"></param>
    /// <returns></returns>
    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] ApplicantDto entity)
    {
        if (repositoryApplicant.Put(id, mapper.Map<Applicant>(entity)))
            return Ok();
        return NotFound();
    }

    /// <summary>
    /// Удаляем Абитуриента по id. А так же удаляем зависимые сущности
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpDelete]
    public IActionResult Delete(int id)
    {
        repositoryExamResult.GetAll()
            .Where(e => e.ApplicantId == id)
            .ToList()
            .ForEach(e => repositoryExamResult.Delete(e.IdExamResult));
        repositoryApplication.GetAll()
            .Where(a => a.ApplicantId == id)
            .ToList()
            .ForEach(a=> repositoryApplication.Delete(a.IdApplication));
        if (repositoryApplicant.Delete(id))
            return Ok();
        return NotFound();
    }
}
