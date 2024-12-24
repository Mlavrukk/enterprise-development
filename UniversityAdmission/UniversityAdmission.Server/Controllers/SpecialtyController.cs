using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using UniversityAdmission.Domain.Class;
using UniversityAdmission.Domain.Dto;
using UniversityAdmission.Domain.Repositories;

namespace UniversityAdmission.Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SpecialtyController(IRepository<Specialty> repositorySpecialty, IRepository<Application> repositoryApplication, IMapper mapper) : Controller
{
    /// <summary>
    /// Получает список Специальностей из репозитория, в формате DtoGet
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public ActionResult<IEnumerable<SpecialtyDtoGet>> Get()
    {
        return Ok(mapper.Map<IEnumerable<SpecialtyDtoGet>>(repositorySpecialty.GetAll()));
    }

    /// <summary>
    /// Получает Специальность из репозитория по id, в формате Dto
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("{id}")]
    public ActionResult<SpecialtyDto> Get(int id)
    {
        var specialty = repositorySpecialty.GetById(id);
        if (specialty == null) { return NotFound(); }
        return Ok(mapper.Map<SpecialtyDto>(specialty));
    }

    /// <summary>
    /// Добавляет Специальность в репозиторий
    /// </summary>
    /// <param name="entity">добавляемая сущность в формате Dto</param>
    /// <returns></returns>
    [HttpPost]
    public IActionResult Post([FromBody] SpecialtyDto entity)
    {
        repositorySpecialty.Post(mapper.Map<Specialty>(entity));
        return Ok();
    }

    /// <summary>
    /// Изменяем поля Специльности по id
    /// </summary>
    /// <param name="id"></param>
    /// <param name="entity"></param>
    /// <returns></returns>
    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] SpecialtyDto entity)
    {
        if (repositorySpecialty.Put(id, mapper.Map<Specialty>(entity)))
            return Ok();
        return NotFound();
    }

    /// <summary>
    /// Удаляем Специальность по id. А так же удаляем зависимые сущности
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpDelete]
    public IActionResult Delete(int id)
    {
        repositoryApplication.GetAll()
            .Where(a => a.SpecialtyId == id)
            .ToList()
            .ForEach(a => repositoryApplication.Delete(a.IdApplication));
        if (repositorySpecialty.Delete(id))
            return Ok();
        return NotFound();
    }
}
