using AutoMapper;
using UniversityAdmission.Domain.Class;
using UniversityAdmission.Domain.Dto;

namespace UniversityAdmission.Domain;

public class Mapper: Profile
{
    public Mapper()
    {
        CreateMap<Applicant, ApplicantDto>().ReverseMap();
        CreateMap<Applicant, ApplicantDtoGet>().ReverseMap();

        CreateMap<Exam, ExamDto>().ReverseMap();
        CreateMap<Exam, ExamDtoGet>().ReverseMap();

        CreateMap<ExamResult, ExamResultDto>().ReverseMap();
        CreateMap<ExamResult, ExamResultDtoGet>().ReverseMap();

        CreateMap<Specialty, SpecialtyDto>().ReverseMap();
        CreateMap<Specialty, SpecialtyDtoGet>().ReverseMap();

        CreateMap<Application, ApplicationDto>().ReverseMap();
        CreateMap<Application, ApplicationDtoGet>().ReverseMap();
    }
}
