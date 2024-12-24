using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using UniversityAdmission.Domain.Class;
using UniversityAdmission.Domain.Dto;
using UniversityAdmission.Domain.Repositories;

namespace UniversityAdmission.Server.Controllers;

[ApiController]
[Route("[controller]")]
public class ExamController(IRepository<Exam> repositoryExam, IMapper mapper) : Controller
{
    [HttpGet]
    public ActionResult<IEnumerable<ExamDtoGet>> Get()
    {
        return Ok(mapper.Map<IEnumerable<ExamDtoGet>>(repositoryExam.GetAll()));
    }
    [HttpGet("{id}")]
    public ActionResult<ExamDto> Get(int id)
    {
        var exam = repositoryExam.GetById(id);
        if (exam == null) { return NotFound(); }
        return Ok(mapper.Map<ExamDto>(exam));
    }
    [HttpPost]
    public IActionResult Post([FromBody] ExamDto entity)
    {
        repositoryExam.Post(mapper.Map<Exam>(entity));
        return Ok();
    }
    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] ExamDto entity)
    {
        if (repositoryExam.Put(id, mapper.Map<Exam>(entity)))
            return Ok();
        return NotFound();
    }

    [HttpDelete]
    public IActionResult Delete(int id)
    {
        // прописать удаление ExamResult 
        if (repositoryExam.Delete(id))
            return Ok();
        return NotFound();

    }
}
