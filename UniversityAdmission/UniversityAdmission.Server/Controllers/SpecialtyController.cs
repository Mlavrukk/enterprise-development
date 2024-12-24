using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using UniversityAdmission.Domain.Class;
using UniversityAdmission.Domain.Dto;
using UniversityAdmission.Domain.Repositories;

namespace UniversityAdmission.Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SpecialtyController(IRepository<Specialty> repositorySpecialty, IRepository<Application> repositoryApplication, IMapper mapper) : ControllerBase
{
    /// <summary>
    /// Получает список Специальностей из репозитория, в формате DtoGet
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public async Task<ActionResult<IEnumerable<SpecialtyDtoGet>>> Get()
    {
        return Ok(mapper.Map<IEnumerable<SpecialtyDtoGet>>(repositorySpecialty.GetAll()));
    }

    /// <summary>
    /// Получает Специальность из репозитория по id, в формате Dto
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("{id}")]
    public async Task<ActionResult<SpecialtyDto>> Get(int id)
    {
        var specialty = await repositorySpecialty.GetById(id);
        if (specialty == null)
            return NoContent();
        return Ok(mapper.Map<SpecialtyDto>(specialty));
    }

    /// <summary>
    /// Добавляет Специальность в репозиторий
    /// </summary>
    /// <param name="entity">добавляемая сущность в формате Dto</param>
    /// <returns></returns>
    [HttpPost]
    public async Task<IActionResult> Post([FromBody] SpecialtyDto entity)
    {
        await repositorySpecialty.Post(mapper.Map<Specialty>(entity));
        return Ok();
    }

    /// <summary>
    /// Изменяем поля Специльности по id
    /// </summary>
    /// <param name="id"></param>
    /// <param name="entity"></param>
    /// <returns></returns>
    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, [FromBody] SpecialtyDto entity)
    {
        if (await repositorySpecialty.Put(id, mapper.Map<Specialty>(entity)))
            return Ok();
        return NoContent();
    }

    /// <summary>
    /// Удаляем Специальность по id. А так же удаляем зависимые сущности
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpDelete]
    public async Task<IActionResult> Delete(int id)
    {
        if (await repositorySpecialty.Delete(id))
            return Ok();
        return NoContent();
    }
}
