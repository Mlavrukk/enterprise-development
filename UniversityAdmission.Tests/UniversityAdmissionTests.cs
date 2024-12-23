using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityAdmission.Domain;
using System.Linq;
using System.Collections.Generic;

namespace UniversityAdmission.Tests
{
    /// <summary>
    /// Класс для тестирования запросов
    /// </summary>
    public class AdmissionTest : IClassFixture<AdmissionFixture>
    {
        private readonly AdmissionFixture fixture;

        public AdmissionTest(AdmissionFixture fixture)
        {
            this.fixture = fixture;
        }

        /// <summary>
        /// Проверка вывода всех абитуриентов
        /// </summary>
        [Fact]
        public void AllApplicants()
        {
            var applicantsInfo =
                from applicant in fixture.Applicants
                orderby applicant.FullName
                select applicant;

            Assert.NotNull(applicantsInfo);
            Assert.Equal(fixture.Applicants.Count, applicantsInfo.Count());
        }

        /// <summary>
        /// Проверка вывода всех заявок на специальности с количеством абитуриентов по каждой специальности
        /// </summary>
        [Fact]
        public void ApplicantsBySpecialty()
        {
            var specialtyCode = "02.02.02"; // Укажите нужный код специальности

            var applicantsForSpecialty =
                from application in fixture.Applications
                join applicant in fixture.Applicants on application.ApplicantId equals applicant.Id
                where application.SpecialtyCode == specialtyCode
                group applicant by application.SpecialtyCode into specialtyGroup
                select new
                {
                    Specialty = specialtyGroup.Key,
                    ApplicantCount = specialtyGroup.Count()
                };

            Assert.NotNull(applicantsForSpecialty);
            Assert.All(applicantsForSpecialty, specialty => Assert.Equal(specialtyCode, specialty.Specialty));
        }

        /// <summary>
        /// Проверка вывода абитуриентов из указанного города
        /// </summary>
        [Fact]
        public void ApplicantsFromCity()
        {
            var city = "Москва"; // Укажите нужный город

            var applicantsInCity =
                from applicant in fixture.Applicants
                where applicant.City == city
                select applicant;

            Assert.NotNull(applicantsInCity);
            Assert.All(applicantsInCity, applicant => Assert.Equal(city, applicant.City));
        }

        /// <summary>
        /// Проверка вывода абитуриентов старше 20 лет, упорядоченных по ФИО
        /// </summary>
        [Fact]
        public void ApplicantsOlderThan20()
        {
            var applicantsOlderThan20 =
                from applicant in fixture.Applicants
                where applicant.DateOfBirth.AddYears(20) < System.DateTime.Now
                orderby applicant.FullName
                select applicant;

            Assert.NotNull(applicantsOlderThan20);
            Assert.All(applicantsOlderThan20, applicant => Assert.True(System.DateTime.Now.Year - applicant.DateOfBirth.Year > 20));
        }

        /// <summary>
        /// Проверка вывода абитуриентов, поступающих на указанную специальность, упорядоченных по сумме баллов
        /// </summary>
        [Fact]
        public void ApplicantsForSpecialtyOrderedByTotalScores()
        {
            var specialtyCode = "CS"; // Укажите код специальности

            var applicantsForSpecialty =
                from applicant in fixture.Applicants
                join application in fixture.Applications on applicant.Id equals application.ApplicantId
                join examResult in fixture.ExamResults on applicant.Id equals examResult.ApplicantId
                where application.SpecialtyCode == specialtyCode
                group examResult by applicant into applicantGroup
                let totalScore = applicantGroup.Sum(exam => exam.Score)
                orderby totalScore descending
                select new
                {
                    Applicant = applicantGroup.Key,
                    TotalScore = totalScore
                };

            Assert.NotNull(applicantsForSpecialty);
            Assert.All(applicantsForSpecialty, applicant => Assert.Equal(specialtyCode, applicant.Applicant.Applications.FirstOrDefault()?.SpecialtyCode));
        }

        /// <summary>
        /// Проверка вывода количества абитуриентов по каждой специальности с первым приоритетом
        /// </summary>
        [Fact]
        public void ApplicantsCountForEachSpecialtyByFirstPriority()
        {
            var applicantsByFirstPriority =
                from application in fixture.Applications
                join applicant in fixture.Applicants on application.ApplicantId equals applicant.Id
                where application.Priority == 1
                group application by application.SpecialtyCode into specialtyGroup
                select new
                {
                    SpecialtyCode = specialtyGroup.Key,
                    ApplicantCount = specialtyGroup.Count()
                };

            Assert.NotNull(applicantsByFirstPriority);
            Assert.True(applicantsByFirstPriority.Any());
        }

        /// <summary>
        /// Проверка вывода топ 5 абитуриентов с наибольшими баллами за три предмета
        /// </summary>
        [Fact]
        public void Top5ApplicantsByTotalScores()
        {
            var top5Applicants =
                (from applicant in fixture.Applicants
                 join examResult in fixture.ExamResults on applicant.Id equals examResult.ApplicantId
                 group examResult by applicant into applicantGroup
                 let totalScore = applicantGroup.Sum(exam => exam.Score)
                 orderby totalScore descending
                 select new
                 {
                     Applicant = applicantGroup.Key,
                     TotalScore = totalScore
                 })
                .Take(5)
                .ToList();

            Assert.NotNull(top5Applicants);
            Assert.Equal(5, top5Applicants.Count());
        }

        /// <summary>
        /// Проверка вывода абитуриентов с максимальными баллами по каждому предмету
        /// </summary>
        [Fact]
        public void TopApplicantsByMaxSubjectScore()
        {
            var maxScoresBySubject =
                from examResult in fixture.ExamResults
                group examResult by examResult.ExamId into subjectGroup
                let maxScore = subjectGroup.Max(exam => exam.Score)
                select new
                {
                    ExamId = subjectGroup.Key,
                    MaxScore = maxScore
                };

            var topApplicantsBySubject =
                from maxScore in maxScoresBySubject
                join examResult in fixture.ExamResults on maxScore.ExamId equals examResult.ExamId
                where examResult.Score == maxScore.MaxScore
                select new
                {
                    Applicant = examResult.Applicant,
                    Exam = examResult.Exam,
                    Score = examResult.Score
                };

            Assert.NotNull(topApplicantsBySubject);
            Assert.All(topApplicantsBySubject, applicant => Assert.Equal(maxScoresBySubject.FirstOrDefault(s => s.ExamId == applicant.Exam.Id)?.MaxScore, applicant.Score));
        }

        /// <summary>
        /// Проверка вывода информации о минимальной, средней и максимальной продолжительности экзаменов
        /// </summary>
        [Fact]
        public void ExamScoresInfo()
        {
            var examScores =
                (from examResult in fixture.ExamResults
                 group examResult by examResult.ExamId into examGroup
                 select examGroup.Sum(exam => exam.Score))
                .ToList();

            var minScore = examScores.Min();
            var maxScore = examScores.Max();
            var averageScore = examScores.Average();

            Assert.NotNull(examScores);
            Assert.Equal(100.0, maxScore);  // Пример: максимальный балл
            Assert.Equal(50.0, minScore);   // Пример: минимальный балл
            Assert.Equal(75.0, averageScore, 1);  // Пример: средний балл
        }
    }
}


namespace UniversityAdmission.Tests
{
    internal class UniversityAdmissionTests
    {
    }
}
