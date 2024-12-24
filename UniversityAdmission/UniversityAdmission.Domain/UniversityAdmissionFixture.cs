using UniversityAdmission.Domain.Class;
namespace UniversityAdmission.Domain;
public class UniversityAdmissionFixture
{
    public List<Applicant> Applicants {  get; set; }
    public List<Application> Applications { get; set; }
    public List<Exam> Exams { get; set; }
    public List<ExamResult> ExamResults { get; set; }
    public List<Specialty> Specialtys { get; set; }

    public UniversityAdmissionFixture()
    {
        Applicants =
        [
            new Applicant
            {
                IdApplicant = -5,
                FullName = "Васин Василий Васильевич",
                DateOfBirth = new DateOnly(2004,12,27),
                Country  = "Россия",
                City = "Самара"
            },
            new Applicant
            {
                IdApplicant = -1,
                FullName = "Иван Иванов Иванович",
                DateOfBirth = new DateOnly(2003,12,15),
                Country  = "Россия",
                City = "Самара"
            },
            new Applicant
            {
                IdApplicant = -2,
                FullName = "Ле Лок Тхо",
                DateOfBirth = new DateOnly(2004,2,3),
                Country  = "Вьетнам",
                City = "Нячанг"
            },
            new Applicant
            {
                IdApplicant = -3,
                FullName = "Стивен Парадез",
                DateOfBirth = new DateOnly(2003,4,10),
                Country  = "Испания",
                City = "Барселона"
            },
            new Applicant
            {
                IdApplicant = -4,
                FullName = "Олег Монгол Викторович",
                DateOfBirth = new DateOnly(2005,1,12),
                Country  = "Россия",
                City = "Орел"
            }
        ];


        Exams =
        [
            new Exam
            {
                Id = -3,
                Name = "Математика",
            },
            new Exam
            {
                Id = -1,
                Name = "Русский Язык",
            },
            new Exam
            {
                Id = -2,
                Name = "Информатика",
            }
        ];


        ExamResults =
        [
            new ExamResult
            {
                IdExamResult = -15,
                ApplicantId = -5,
                ExamId = 0,
                Score = 46
            },
            new ExamResult
            {
                IdExamResult = -1,
                ApplicantId = -5,
                ExamId = -1,
                Score = 52
            },
            new ExamResult
            {
                IdExamResult = -2,
                ApplicantId = -5,
                ExamId = -2,
                Score = 1
            },


            new ExamResult
            {
                IdExamResult = -3,
                ApplicantId = -1,
                ExamId = -3,
                Score = 41
            },
            new ExamResult
            {
                IdExamResult = -4,
                ApplicantId = -1,
                ExamId = -1,
                Score = 52
            },
            new ExamResult
            {
                IdExamResult = -5,
                ApplicantId = -1,
                ExamId = -2,
                Score = 12
            },


            new ExamResult
            {
                IdExamResult = -6,
                ApplicantId = -2,
                ExamId = -3,
                Score = 100
            },
            new ExamResult
            {
                IdExamResult = -7,
                ApplicantId = -2,
                ExamId = -1,
                Score = 52
            },
            new ExamResult
            {
                IdExamResult = -8,
                ApplicantId = -2,
                ExamId = -2,
                Score = 100
            },


            new ExamResult
            {
                IdExamResult = -9,
                ApplicantId = -3,
                ExamId = -3,
                Score = 46
            },
            new ExamResult
            {
                IdExamResult = -10,
                ApplicantId = -3,
                ExamId = 1,
                Score = 12
            },
            new ExamResult
            {
                IdExamResult = -11,
                ApplicantId = -3,
                ExamId = -2,
                Score = 12
            },


            new ExamResult
            {
                IdExamResult = -12,
                ApplicantId = -4,
                ExamId = -3,
                Score = 52
            },
            new ExamResult
            {
                IdExamResult = -13,
                ApplicantId = -4,
                ExamId = -1,
                Score = 52
            },
            new ExamResult
            {
                IdExamResult = -14,
                ApplicantId = -4,
                ExamId = -2,
                Score = 52
            },
        ];


        Specialtys =
        [
            new Specialty
            {
                IdSpecialty = -2,
                Code = "10.05.03D",
                Name = "Ибас",
                Faculty = "ИИК"
            },
            new Specialty
            {
                IdSpecialty = -1,
                Code = "10.05.04D",
                Name = "ФИИТ",
                Faculty = "ИИК"
            }
        ];


        Applications =
        [
            new Application
            {
                IdApplication = -1,
                ApplicantId = -5,
                SpecialtyId = -2,
                Priority = 0,
            }
        ];
    }
}