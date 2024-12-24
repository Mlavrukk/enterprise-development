using UniversityAdmission.Domain.Repositories;
using UniversityAdmission.Domain.Class;
using UniversityAdmission.Domain.Dto.DtoForRequest;
using AutoMapper;
using UniversityAdmission.Domain.Dto;
using Microsoft.AspNetCore.Mvc;

namespace UniversityAdmission.Server.Servicies;

public class AnalayzerService(IRepository<Applicant> repositoryApplicant, IRepository<Application> repositoryApplication, IRepository<Exam> repositoryExam, IRepository<ExamResult> repositoryExamResult, IRepository<Specialty> repositorySpecialty, IMapper mapper) : IAnalayzerService
{
    public async Task<IEnumerable<ApplicantDtoGet>> GetApplicantByCity(string city)
    {
        var request = (from applicant in await repositoryApplicant.GetAll()
                       where applicant.City == city
                       select applicant);
        return mapper.Map<IEnumerable<ApplicantDtoGet>>(request);
    }

    public async Task<IEnumerable<ApplicantDtoGet>> GetApplicantOlderValue(int ageLimit)
    {
        DateOnly currentDate = DateOnly.FromDateTime(DateTime.Now);
        var request = (await repositoryApplicant.GetAll())
           .Where(applicant =>
           {
               int age = currentDate.Year - applicant.DateOfBirth.Year;
               if ((currentDate.Month < applicant.DateOfBirth.Month) ||
               (currentDate.Month == applicant.DateOfBirth.Month && currentDate.Day < applicant.DateOfBirth.Day))
               {
                   age--;
               }

               return age > ageLimit;
           })
           .OrderBy(applicant => applicant.FullName);

        return mapper.Map<IEnumerable<ApplicantDtoGet>>(request);
    }
    public async Task<IEnumerable<ApplicantDtoWithExamResult>> GetApplicantsBySpecialtySortedByExamScores(string specialtyCode)
    {
        var request = (from applicant in (await repositoryApplicant.GetAll())
                       join application in (await repositoryApplication.GetAll()) on applicant.IdApplicant equals application.ApplicantId
                       join specialty in (await repositorySpecialty.GetAll()) on application.SpecialtyId equals specialty.IdSpecialty
                       join examResult in (await repositoryExamResult.GetAll()) on applicant.IdApplicant equals examResult.ApplicantId
                       where specialty.Code == specialtyCode
                       group examResult by new
                       {
                           Applicant = applicant,
                           SpecialtyName = specialty.Name
                       } into applicantGroup
                       let totalScore = applicantGroup.Sum(exam => exam.Score)
                       orderby totalScore descending
                       select new ApplicantDtoWithExamResult
                       {
                           Applicant = applicantGroup.Key.Applicant,
                           SumExamResult = totalScore
                       })
                       .ToList();
        return request;

    }

    public async Task<IEnumerable<ApplicantCountForSpecialityDto>> GetCountApplicantToSpecialty()
    {
        var request = (from application in (await repositoryApplication.GetAll())
                       join specialty in (await repositorySpecialty.GetAll()) on application.SpecialtyId equals specialty.IdSpecialty
                       where application.Priority == 0
                       group application by specialty.IdSpecialty into specialtyGroup
                       select new ApplicantCountForSpecialityDto
                       {
                           SpecialtyId = specialtyGroup.Key,
                           ApplicantCount = specialtyGroup.Count()
                       })
                       .ToList();
        return request;
    }

    public async Task<IEnumerable<TopFiveApplicantDto>> GetTopFiveApplicantToScore()
    {
        var request = (from examResult in (await repositoryExamResult.GetAll())
                       join applicant in (await repositoryApplicant.GetAll()) on examResult.ApplicantId equals applicant.IdApplicant
                       group examResult by applicant into applicantGroup
                       let totalScore = applicantGroup.Sum(result => result.Score)
                       orderby totalScore descending
                       select new TopFiveApplicantDto
                       {
                           Applicant = applicantGroup.Key,
                           TotalScore = totalScore
                       })
                       .Take(5)
                       .ToList();
        return request;
    }
    public async Task<IEnumerable<ApplicantWithMaxScoreWithSpecialty>> GetApplicantAndSpecialtyMaxScore()
    {
        var applicants = await repositoryApplicant.GetAll();
        var applications = await repositoryApplication.GetAll();
        var request = (from examResult in (await repositoryExamResult.GetAll())
                       join applicant in applicants on examResult.ApplicantId equals applicant.IdApplicant
                       join application in applications on applicant.IdApplicant equals application.ApplicantId
                       join specialty in (await repositorySpecialty.GetAll()) on application.SpecialtyId equals specialty.IdSpecialty
                       group examResult by examResult.ExamId into examGroup
                       let maxScore = examGroup.Max(result => result.Score)
                       select new ApplicantWithMaxScoreWithSpecialty
                       {
                           Applicant = (from result in examGroup
                                        where result.Score == maxScore
                                        join applicant in applicants on result.ApplicantId equals applicant.IdApplicant
                                        select applicant).FirstOrDefault(),
                           MaxScore = maxScore,
                           SpecialtyId = (from result in examGroup
                                          where result.Score == maxScore
                                          join applicant in applicants on result.ApplicantId equals applicant.IdApplicant
                                          join application in applications on applicant.IdApplicant equals application.ApplicantId
                                          select application.SpecialtyId).FirstOrDefault()
                       })
                       .ToList();

        return request;
    }


}
