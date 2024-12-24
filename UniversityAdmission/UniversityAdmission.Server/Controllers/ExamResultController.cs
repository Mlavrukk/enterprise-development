using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using UniversityAdmission.Domain.Class;
using UniversityAdmission.Domain.Dto;
using UniversityAdmission.Domain.Repositories;

namespace UniversityAdmission.Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ExamResultController(IRepository<ExamResult> repositoryExamResult, IRepository<Exam> repositoryExam, IRepository<Applicant> repositoryApplicant, IMapper mapper) : Controller
{
    /// <summary>
    /// Получает список Результатов за Экзамен из репозитория, в формате DtoGet
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public async Task<ActionResult<IEnumerable<ExamResultDtoGet>>> Get()
    {
        return Ok(mapper.Map<IEnumerable<ExamResultDtoGet>>(await repositoryExamResult.GetAll()));
    }

    /// <summary>
    /// Получает Результат за Экзамен из репозитория по id, в формате Dto
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("{id}")]
    public async Task<ActionResult<ExamResultDto>> Get(int id)
    {
        var applicant = await repositoryExamResult.GetById(id);
        if (applicant == null)
            return NoContent();
        return Ok(mapper.Map<ExamResultDto>(applicant));
    }

    /// <summary>
    /// Добавляет Результат за Экзамен в репозиторий
    /// </summary>
    /// <param name="entity">добавляемая сущность в формате Dto</param>
    /// <returns></returns>
    [HttpPost]
    public async Task<IActionResult> Post([FromBody] ExamResultDto entity)
    {
        var applicant = await repositoryApplicant.GetById(entity.ApplicantId);
        var exam = await repositoryExam.GetById(entity.ExamId);
        if (applicant == null)
            return NotFound($"Applicant c таким id({entity.ApplicantId}) не найден");
        if (exam == null)
            return NotFound($"Exam c таким id({entity.ExamId}) не найден");
        await repositoryExamResult.Post(mapper.Map<ExamResult>(entity));
        return Ok();
    }

    /// <summary>
    /// Изменяем поля Результата за Экзамен по id
    /// </summary>
    /// <param name="id"></param>
    /// <param name="entity"></param>
    /// <returns></returns>
    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, [FromBody] ExamResultDto entity)
    {
        if (await repositoryExamResult.Put(id, mapper.Map<ExamResult>(entity)))
            return Ok();
        return NoContent();
    }
    /// <summary>
    /// Удаляем Результат за Экзамен по id.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpDelete]
    public async Task<IActionResult> Delete(int id)
    {
        if (await repositoryExamResult.Delete(id))
            return Ok();
        return NoContent();
    }
}
