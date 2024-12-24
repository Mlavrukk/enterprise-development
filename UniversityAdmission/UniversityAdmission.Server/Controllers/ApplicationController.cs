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
    [HttpGet]
    public ActionResult<IEnumerable<ApplicationDtoGet>> Get()
    {
        return Ok(mapper.Map<IEnumerable<ApplicationDtoGet>>(repositoryApplication.GetAll()));
    }
    [HttpGet("{id}")]
    public ActionResult<ApplicationDto> Get(int id)
    {
        var application = repositoryApplication.GetById(id);
        if (application == null) { return NotFound(); }
        return Ok(mapper.Map<ApplicationDto>(application));
    }
    [HttpPost]
    public IActionResult Post([FromBody] ApplicationDto entity)
    {
        var applicant = repositoryApplicant.GetById(entity.ApplicantId);
        var specialty = repositorySpecialty.GetById(entity.SpecialtyId);
        if(specialty == null)
            return NotFound($"Специальность с такимм id({entity.SpecialtyId}) не найдена");
        if (applicant == null)
            return NotFound($"Абитуриент с таким id({entity.ApplicantId}) не найден");
        repositoryApplication.Post(mapper.Map<Application>(entity));
        return Ok();
    }
    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] ApplicationDto entity)
    {
        if (repositoryApplication.Put(id, mapper.Map<Application>(entity)))
            return Ok();
        return NotFound();
    }

    [HttpDelete]
    public IActionResult Delete(int id)
    {
        if (repositoryApplication.Delete(id))
            return Ok();
        return NotFound();
    }
}
