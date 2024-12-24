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
    [HttpGet]
    public ActionResult<IEnumerable<SpecialtyDtoGet>> Get()
    {
        return Ok(mapper.Map<IEnumerable<SpecialtyDtoGet>>(repositorySpecialty.GetAll()));
    }
    [HttpGet("{id}")]
    public ActionResult<SpecialtyDto> Get(int id)
    {
        var specialty = repositorySpecialty.GetById(id);
        if (specialty == null) { return NotFound(); }
        return Ok(mapper.Map<SpecialtyDto>(specialty));
    }
    [HttpPost]
    public IActionResult Post([FromBody] SpecialtyDto entity)
    {
        repositorySpecialty.Post(mapper.Map<Specialty>(entity));
        return Ok();
    }
    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] SpecialtyDto entity)
    {
        if (repositorySpecialty.Put(id, mapper.Map<Specialty>(entity)))
            return Ok();
        return NotFound();
    }

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
