using UniversityAdmission.Domain.Class;
namespace UniversityAdmission.Test;

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
                IdApplicant = 0,
                FullName = "Васин Василий Васильевич",
                DateOfBirth = new DateOnly(2003,7,11),
                Country  = "Россия",
                City = "Самара"
            },
            new Applicant
            {
                IdApplicant = 1,
                FullName = "Иван Иванов Иванович",
                DateOfBirth = new DateOnly(2003,12,15),
                Country  = "Россия",
                City = "Самара"
            },
            new Applicant
            {
                IdApplicant = 2,
                FullName = "Ле Лок Тхо",
                DateOfBirth = new DateOnly(2004,2,3),
                Country  = "Вьетнам",
                City = "Нячанг"
            },
            new Applicant
            {
                IdApplicant = 3,
                FullName = "Стивен Парадез",
                DateOfBirth = new DateOnly(2003,4,10),
                Country  = "Испания",
                City = "Барселона"
            },
            new Applicant
            {
                IdApplicant = 4,
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
                IdExam = 0,
                Name = "Математика",
            }
        ];


        ExamResults =
        [
            new ExamResult
            {
                IdExamResult = 0,
                ApplicantId = 0,
                ExamId = 0,
                Score = 46,

            }
        ];

        Specialtys =
        [
            new Specialty
            {
                IdSpecialty = 0,
                Code = "10.05.03D",
                Name = "Ибас",
                Faculty = "ИИК"
            }
        ];
    }
}