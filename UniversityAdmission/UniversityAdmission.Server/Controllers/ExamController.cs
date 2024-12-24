using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using UniversityAdmission.Domain.Class;
using UniversityAdmission.Domain.Dto;
using UniversityAdmission.Domain.Repositories;

namespace UniversityAdmission.Server.Controllers;

[ApiController]
[Route("[controller]")]
public class ExamController(IRepository<Exam> repositoryExam, IRepository<ExamResult> repositoryExamResult, IMapper mapper) : Controller
{
    /// <summary>
    /// Получает список Экзаменов из репозитория, в формате DtoGet
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public ActionResult<IEnumerable<ExamDtoGet>> Get()
    {
        return Ok(mapper.Map<IEnumerable<ExamDtoGet>>(repositoryExam.GetAll()));
    }

    /// <summary>
    /// Получает Экзамен из репозитория по id, в формате Dto
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("{id}")]
    public ActionResult<ExamDto> Get(int id)
    {
        var exam = repositoryExam.GetById(id);
        if (exam == null) { return NotFound(); }
        return Ok(mapper.Map<ExamDto>(exam));
    }

    /// <summary>
    /// Добавляет Экзамен в репозиторий
    /// </summary>
    /// <param name="entity">добавляемая сущность в формате Dto</param>
    /// <returns></returns>
    [HttpPost]
    public IActionResult Post([FromBody] ExamDto entity)
    {
        repositoryExam.Post(mapper.Map<Exam>(entity));
        return Ok();
    }

    /// <summary>
    /// Изменяем поля Экзамена по id
    /// </summary>
    /// <param name="id"></param>
    /// <param name="entity"></param>
    /// <returns></returns>
    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] ExamDto entity)
    {
        if (repositoryExam.Put(id, mapper.Map<Exam>(entity)))
            return Ok();
        return NotFound();
    }

    /// <summary>
    /// Удаляем Экзамен по id. А так же удаляем зависимые сущности
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpDelete]
    public IActionResult Delete(int id)
    {
        repositoryExamResult.GetAll()
            .Where(e => e.ExamId == id)
            .ToList()
            .ForEach(e => repositoryExamResult.Delete(e.IdExamResult));
        if (repositoryExam.Delete(id))
            return Ok();
        return NotFound();

    }
}
