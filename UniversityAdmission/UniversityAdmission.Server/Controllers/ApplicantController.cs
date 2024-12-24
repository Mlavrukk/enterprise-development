using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using UniversityAdmission.Domain.Class;
using UniversityAdmission.Domain.Dto;
using UniversityAdmission.Domain.Repositories;

namespace UniversityAdmission.Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ApplicantController(IRepository<Applicant> repositoryApplicant, IRepository<ExamResult> repositoryExamResult, IRepository<Application> repositoryApplication, IMapper mapper) : ControllerBase
{
    /// <summary>
    /// Получает список Абитуриентов из репозитория, в формате DtoGet
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public async Task<ActionResult<IEnumerable<ApplicantDtoGet>>> Get()
    {
        return Ok(mapper.Map<IEnumerable<ApplicantDtoGet>>(await repositoryApplicant.GetAll()));
    }

    /// <summary>
    /// Получает Абитуриента из репозитория по id, в формате Dto
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("{id}")]
    public async Task<ActionResult<ApplicantDto>> Get(int id)
    {
        var applicant = await repositoryApplicant.GetById(id);
        if (applicant == null)
            return NoContent();
        return Ok(mapper.Map<ApplicantDto>(applicant));
    }

    /// <summary>
    /// Добавляет Абитуриента в репозиторий
    /// </summary>
    /// <param name="entity">добавляемая сущность в формате Dto</param>
    /// <returns></returns>
    [HttpPost]
    public async Task<IActionResult> Post([FromBody] ApplicantDto entity)
    {
        await repositoryApplicant.Post(mapper.Map<Applicant>(entity));
        return Ok();
    }

    /// <summary>
    /// Изменяем поля Абитуриента по id
    /// </summary>
    /// <param name="id"></param>
    /// <param name="entity"></param>
    /// <returns></returns>
    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, [FromBody] ApplicantDto entity)
    {
        if (await repositoryApplicant.Put(id, mapper.Map<Applicant>(entity)))
            return Ok();
        return NoContent();
    }

    /// <summary>
    /// Удаляем Абитуриента по id. А так же удаляем зависимые сущности
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpDelete]
    public async Task<IActionResult> Delete(int id)
    {
        if (await repositoryApplicant.Delete(id))
            return Ok();
        return NoContent();
    }
}
