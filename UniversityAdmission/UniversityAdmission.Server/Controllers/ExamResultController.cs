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
    [HttpGet]
    public ActionResult<IEnumerable<ExamResultDtoGet>> Get()
    {
        return Ok(mapper.Map<IEnumerable<ExamResultDtoGet>>(repositoryExamResult.GetAll()));
    }
    [HttpGet("{id}")]
    public ActionResult<ExamResultDto> Get(int id)
    {
        var applicant = repositoryExamResult.GetById(id);
        if (applicant == null) { return NotFound(); }
        return Ok(mapper.Map<ExamResultDto>(applicant));
    }
    [HttpPost]
    public IActionResult Post([FromBody] ExamResultDto entity)
    {
        var applicant = repositoryApplicant.GetById(entity.ApplicantId);
        var exam = repositoryExam.GetById(entity.ExamId);
        if (applicant == null)
            return NotFound($"Applicant c таким id({entity.ApplicantId}) не найден");
        if (exam == null)
            return NotFound($"Exam c таким id({entity.ExamId}) не найден");
        repositoryExamResult.Post(mapper.Map<ExamResult>(entity));
        return Ok();
    }
    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] ExamResultDto entity)
    {
        if (repositoryExamResult.Put(id, mapper.Map<ExamResult>(entity)))
            return Ok();
        return NotFound();
    }

    [HttpDelete]
    public IActionResult Delete(int id)
    {
        if (repositoryExamResult.Delete(id))
            return Ok();
        return NotFound();
    }
}
