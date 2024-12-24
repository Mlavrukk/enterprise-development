using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using UniversityAdmission.Domain.Class;
using UniversityAdmission.Domain.Dto;
using UniversityAdmission.Domain.Repositories;

namespace UniversityAdmission.Server.Controllers;

[ApiController]
[Route("[controller]")]
public class ExamController(IRepository<Exam> repositoryExam, IRepository<ExamResult> repositoryExamResult, IMapper mapper) : ControllerBase
{
    /// <summary>
    /// Получает список Экзаменов из репозитория, в формате DtoGet
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    [ProducesResponseType(200)]
    public async Task<ActionResult<IEnumerable<ExamDtoGet>>> Get()
    {
        return Ok(mapper.Map<IEnumerable<ExamDtoGet>>(await repositoryExam.GetAll()));
    }

    /// <summary>
    /// Получает Экзамен из репозитория по id, в формате Dto
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("{id}")]
    [ProducesResponseType(200)]
    [ProducesResponseType(204)]
    public async Task<ActionResult<ExamDto>> Get(int id)
    {
        var exam = await repositoryExam.GetById(id);
        if (exam == null)
            return NoContent();
        return Ok(mapper.Map<ExamDto>(exam));
    }

    /// <summary>
    /// Добавляет Экзамен в репозиторий
    /// </summary>
    /// <param name="entity">добавляемая сущность в формате Dto</param>
    /// <returns></returns>
    [HttpPost]
    [ProducesResponseType(200)]
    public async Task<IActionResult> Post([FromBody] ExamDto entity)
    {
        await repositoryExam.Post(mapper.Map<Exam>(entity));
        return Ok();
    }

    /// <summary>
    /// Изменяем поля Экзамена по id
    /// </summary>
    /// <param name="id"></param>
    /// <param name="entity"></param>
    /// <returns></returns>
    [HttpPut("{id}")]
    [ProducesResponseType(200)]
    [ProducesResponseType(204)]
    public async Task<IActionResult> Put(int id, [FromBody] ExamDto entity)
    {
        if (await repositoryExam.Put(id, mapper.Map<Exam>(entity)))
            return Ok();
        return NoContent();
    }

    /// <summary>
    /// Удаляем Экзамен по id. А так же удаляем зависимые сущности
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpDelete]
    [ProducesResponseType(200)]
    [ProducesResponseType(204)]
    public async Task<IActionResult> Delete(int id)
    {
        if (await repositoryExam.Delete(id))
            return Ok();
        return NoContent();

    }
}
