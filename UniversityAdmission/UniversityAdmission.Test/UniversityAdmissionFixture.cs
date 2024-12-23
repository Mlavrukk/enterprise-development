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
                FullName = "����� ������� ����������",
                DateOfBirth = new DateOnly(2003,7,11),
                Country  = "������",
                City = "������"
            },
            new Applicant
            {
                IdApplicant = 1,
                FullName = "���� ������ ��������",
                DateOfBirth = new DateOnly(2003,12,15),
                Country  = "������",
                City = "������"
            },
            new Applicant
            {
                IdApplicant = 2,
                FullName = "�� ��� ���",
                DateOfBirth = new DateOnly(2004,2,3),
                Country  = "�������",
                City = "������"
            },
            new Applicant
            {
                IdApplicant = 3,
                FullName = "������ �������",
                DateOfBirth = new DateOnly(2003,4,10),
                Country  = "�������",
                City = "���������"
            },
            new Applicant
            {
                IdApplicant = 4,
                FullName = "���� ������ ����������",
                DateOfBirth = new DateOnly(2005,1,12),
                Country  = "������",
                City = "����"
            }
        ];



        Exams =
        [
            new Exam
            {
                IdExam = 0,
                Name = "����������",
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
                Name = "����",
                Faculty = "���"
            }
        ];
    }
}