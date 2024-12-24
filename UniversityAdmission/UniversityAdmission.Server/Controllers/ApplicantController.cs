using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using UniversityAdmission.Domain.Class;
using UniversityAdmission.Domain.Dto;
using UniversityAdmission.Domain.Repositories;

namespace UniversityAdmission.Server.Controllers;

[ApiController]
[Route("[controller]")]
public class ApplicantController(IRepository<Applicant> repositoryApplicant, IRepository<ExamResult> repositoryExamResult, IRepository<Application> repositoryApplication, IMapper mapper) : Controller
{
    [HttpGet]
    public ActionResult<IEnumerable<ApplicantDtoGet>> Get()
    {
        return Ok(mapper.Map<IEnumerable<ApplicantDtoGet>>(repositoryApplicant.GetAll()));
    }
    [HttpGet("{id}")]
    public ActionResult<ApplicantDto> Get(int id)
    {
        var applicant = repositoryApplicant.GetById(id);
        if (applicant == null) { return NotFound(); }
        return Ok(mapper.Map<ApplicantDto>(applicant));
    }
    [HttpPost]
    public IActionResult Post([FromBody] ApplicantDto entity)
    {
        repositoryApplicant.Post(mapper.Map<Applicant>(entity));
        return Ok();
    }
    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] ApplicantDto entity)
    {
        if (repositoryApplicant.Put(id, mapper.Map<Applicant>(entity)))
            return Ok();
        return NotFound();
    }

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
