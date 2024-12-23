namespace UniversityAdmission.Test;
public class UniversityAdmissionTests
{
    private readonly UniversityAdmissionFixture _data = new UniversityAdmissionFixture();

    /// <summary>
    /// 1) Вывести информацию об абитуриентах из указанного города.
    /// </summary>
    [Fact]
    public void TestGetApplicantFromCity()
    {
        var city = "Самара";
        var request = (from applicant in _data.Applicants
                      where applicant.City == city
                      select applicant)
                      .ToList();
        Assert.Equal(2, request.Count());
    }

    /// <summary>
    /// 2) Вывести информацию об абитуриентах старше 20 лет, упорядочить по ФИО.
    /// </summary>
    [Fact]
    public void TesGetApplicantOlder20()
    {
        int ageLimit = 20;
        DateOnly currentDate = DateOnly.FromDateTime(DateTime.Now); // Текущая дата

        var request = _data.Applicants
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
            .OrderBy(applicant => applicant.FullName)
            .ToList(); 
        Assert.Equal(2, request.Count()); 
    }

    /// <summary>
    /// 3) Вывести информацию об абитуриентах, поступающих на указанную
    /// специальность(без учета приоритета), упорядочить по сумме баллов за
    /// экзамены.
    /// </summary>
    [Fact]
    public void TestGetApplicantsBySpecialtySortedByExamScores()
    {
        string specialtyCode = "10.05.03D"; 

        var request = (from applicant in _data.Applicants
                       join application in _data.Applications on applicant.IdApplicant equals application.IdApplication
                       join specialty in _data.Specialtys on application.SpecialtyId equals specialty.IdSpecialty
                       join examResult in _data.ExamResults on applicant.IdApplicant equals examResult.ApplicantId
                       where specialty.Code == specialtyCode
                       group examResult by new
                       {
                           applicant.IdApplicant,
                           applicant.FullName,
                           applicant.City,
                           applicant.Country
                       } into applicantGroup
                       let totalScore = applicantGroup.Sum(exam => exam.Score)
                       orderby totalScore descending
                       select applicantGroup)
                       .ToList();
            Assert.NotEmpty(request);
    }

    /// <summary>
    /// 4) Вывести информацию о количестве абитуриентов, поступающих на каждую
    /// специальность по первому приоритету.
    /// </summary>
    [Fact]
    public void TestGetCountApplicantToSpecialty()
    {
        var request = (from application in _data.Applications
                       join specialty in _data.Specialtys on application.SpecialtyId equals specialty.IdSpecialty
                       where application.Priority == 0
                       group application by specialty.Name into specialtyGroup
                       select new
                       {
                           SpecialtyName = specialtyGroup.Key,
                           ApplicantCount = specialtyGroup.Count()
                       })
                       .ToList();

        Assert.NotEmpty(request);
    }

    /// <summary>
    /// 5) Вывести информацию о топ 5 абитуриентах, набравших наибольшее число
    /// баллов за три предмета.
    /// </summary>
    [Fact]
    public void TestTopFiveApplicantToScore()
    {
        var request = (from examResult in _data.ExamResults
                       join applicant in _data.Applicants on examResult.ApplicantId equals applicant.IdApplicant
                       group examResult by new
                       {
                           applicant.IdApplicant,
                           applicant.FullName
                       } into applicantGroup
                       let totalScore = applicantGroup.Sum(result => result.Score)
                       orderby totalScore descending
                       select new
                       {
                           Applicant = applicantGroup.Key,
                           TotalScore = totalScore
                       })
                       .Take(5)
                       .ToList();

        Assert.Equal(5, request.Count);
    }

    /// <summary>
    /// 6) Вывести информацию об абитуриентах(и их приоритетных
    /// специальностях), которые набрали максимальный балл по каждому из
    /// предметов.
    /// </summary>
    [Fact]
    public void TestApplicantAndSpecialtyMaxScore()
    {
        var request = (from examResult in _data.ExamResults
                       join applicant in _data.Applicants on examResult.ApplicantId equals applicant.IdApplicant
                       join application in _data.Applications on applicant.IdApplicant equals application.ApplicantId
                       join specialty in _data.Specialtys on application.SpecialtyId equals specialty.IdSpecialty
                       group examResult by examResult.ExamId into examGroup
                       let maxScore = examGroup.Max(result => result.Score)
                       select new
                       {
                           ExamId = examGroup.Key,
                           MaxScore = maxScore,
                           Applicants = (from result in examGroup
                                         where result.Score == maxScore
                                         join applicant in _data.Applicants on result.ApplicantId equals applicant.IdApplicant
                                         join application in _data.Applications on applicant.IdApplicant equals application.ApplicantId
                                         join specialty in _data.Specialtys on application.SpecialtyId equals specialty.IdSpecialty
                                         select new
                                         {
                                             Applicant = applicant.FullName,
                                             Specialty = specialty.Name
                                         }).ToList()
                       })
                       .ToList();

        Assert.NotEmpty(request);
    }
}
