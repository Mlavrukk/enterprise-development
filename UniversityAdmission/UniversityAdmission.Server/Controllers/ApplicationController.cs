using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using UniversityAdmission.Domain.Class;
using UniversityAdmission.Domain.Dto;
using UniversityAdmission.Domain.Repositories;

namespace UniversityAdmission.Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ApplicationController(IRepository<Application> repositoryApplication, IRepository<Applicant> repositoryApplicant, IRepository<Specialty> repositorySpecialty, IMapper mapper) : Controller
{
    /// <summary>
    /// Получает список Заявлений из репозитория, в формате DtoGet
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public async Task<ActionResult<IEnumerable<ApplicationDtoGet>>> Get()
    {
        return Ok(mapper.Map<IEnumerable<ApplicationDtoGet>>(await repositoryApplication.GetAll()));
    }

    /// <summary>
    /// Получает Заявление из репозитория по id, в формате Dto
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("{id}")]
    public async Task<ActionResult<ApplicationDto>> Get(int id)
    {
        var application = await repositoryApplication.GetById(id);
        if (application == null)
            return NoContent();
        return Ok(mapper.Map<ApplicationDto>(application));
    }

    /// <summary>
    /// Добавляет Заявление в репозиторий
    /// </summary>
    /// <param name="entity">добавляемая сущность в формате Dto</param>
    /// <returns></returns>
    [HttpPost]
    public async Task<IActionResult> Post([FromBody] ApplicationDto entity)
    {
        var applicant = await repositoryApplicant.GetById(entity.ApplicantId);
        var specialty = await repositorySpecialty.GetById(entity.SpecialtyId);
        if (specialty == null)
            return NotFound($"Специальность с такимм id({entity.SpecialtyId}) не найдена");
        if (applicant == null)
            return NotFound($"Абитуриент с таким id({entity.ApplicantId}) не найден");
        await repositoryApplication.Post(mapper.Map<Application>(entity));
        return Ok();
    }

    /// <summary>
    /// Изменяем поля Заявления по id
    /// </summary>
    /// <param name="id"></param>
    /// <param name="entity"></param>
    /// <returns></returns>
    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, [FromBody] ApplicationDto entity)
    {
        if (await repositoryApplication.Put(id, mapper.Map<Application>(entity)))
            return Ok();
        return NoContent();
    }

    /// <summary>
    /// Удаляем Заявление по id.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpDelete]
    public async Task<IActionResult> Delete(int id)
    {
        if (await repositoryApplication.Delete(id))
            return Ok();
        return NoContent();
    }
}
