using System;
using System.Collections.Generic;
using UniversityAdmission.Domain.Entities;
using static System.Net.Mime.MediaTypeNames;

namespace UniversityAdmission.Tests
{
    /// <summary>
    /// Класс для тестовых данных
    /// </summary>
    public class UniversityAdmissionFixture
    {
        /// <summary>
        /// Список абитуриентов
        /// </summary>
        public List<Applicant> Applicants { get; }

        /// <summary>
        /// Список специальностей
        /// </summary>
        public List<Specialty> Specialties { get; }

        /// <summary>
        /// Список экзаменов
        /// </summary>
        public List<Exam> Exams { get; }

        /// <summary>
        /// Список результатов экзаменов
        /// </summary>
        public List<ExamResult> ExamResults { get; }

        /// <summary>
        /// Список заявлений
        /// </summary>
        public List<Application> Applications { get; }

        /// <summary>
        /// Инициализация тестовых данных
        /// </summary>
        public UniversityAdmissionFixture()
        {
            // Инициализация списка абитуриентов
            Applicants = new List<Applicant>
            {
                new() 
                { 
                    Id = 1, 
                    FullName = "Иван Иванов", 
                    DateOfBirth = new DateTime(2000, 1, 1), 
                    Country = "Россия", City = "Москва" 
                },

                new() 
                { 
                    Id = 2, 
                    FullName = "Мария Петрова", 
                    DateOfBirth = new DateTime(2001, 5, 15), 
                    Country = "Россия", 
                    City = "Санкт-Петербург" 
                },
                
                new() 
                { 
                    Id = 3, 
                    FullName = "Алексей Смирнов", 
                    DateOfBirth = new DateTime(2000, 11, 30), 
                    Country = "Россия", 
                    City = "Новосибирск" 
                },

                new()
                {
                    Id = 4,
                    FullName = "Дмитрий Сидоров",
                    DateOfBirth = new DateTime(2005, 12, 17),
                    Country = "Россия",
                    City = "Самара"

                },

                  new()
                {
                    Id = 5,
                    FullName = "София Мишанина",
                    DateOfBirth = new DateTime(2004, 7, 27),
                    Country = "Россия",
                    City = "Сочи"

                },

                    new()
                {
                    Id = 6,
                    FullName = "Варвара Николаева",
                    DateOfBirth = new DateTime(2003, 8, 23),
                    Country = "Россия",
                    City = "Москва"

                }
            };

            // Инициализация списка специальностей
            Specialties = new List<Specialty>
            {
                new() 
                { 
                    Code = "01.01.01", 
                    Name = "Программирование", 
                    Faculty = "Факультет информационных технологий" 
                },
                
                new() 
                { 
                    Code = "02.02.02",
                    Name = "Математика",
                    Faculty = "Факультет математики и механики" 
                },

                new() 
                { 
                    Code = "03.03.03", 
                    Name = "Физика", 
                    Faculty = "Факультет физики" 
                }
            };

            // Инициализация списка экзаменов
            Exams = new List<Exam>
            {
                new() 
                { 
                    Id = 1, 
                    Name = "Математика" 
                },

                new() 
                { 
                    Id = 2, 
                    Name = "Физика" 
                },

                new() 
                { 
                    Id = 3, 
                    Name = "Информатика" 
                }
            };

            // Инициализация списка результатов экзаменов
            ExamResults = new List<ExamResult>
            {
                new() 
                { 
                    Id = 1, 
                    ApplicantId = 1, 
                    ExamId = 1, 
                    Score = 85.5 
                },

                new() 
                { 
                    Id = 2, 
                    ApplicantId = 1, 
                    ExamId = 2, 
                    Score = 90.0 
                },

                new() 
                { 
                    Id = 3, 
                    ApplicantId = 2, 
                    ExamId = 1, 
                    Score = 92.0 
                },

                new() 
                { 
                    Id = 4, 
                    ApplicantId = 2, 
                    ExamId = 3, 
                    Score = 88.0 
                },

                new() 
                { 
                    Id = 5, 
                    ApplicantId = 3, 
                    ExamId = 1, 
                    Score = 78.0 
                },

                new() 
                { 
                    Id = 6, 
                    ApplicantId = 3, 
                    ExamId = 2, 
                    Score = 85.0 
                },

                 new()
                {
                    Id = 7,
                    ApplicantId = 4,
                    ExamId = 1,
                    Score = 57.0
                },

                  new()
                {
                    Id = 8,
                    ApplicantId = 4,
                    ExamId = 2,
                    Score = 75.0
                },

                   new()
                {
                    Id = 9,
                    ApplicantId = 5,
                    ExamId = 2,
                    Score = 63.0
                },

                    new()
                {
                    Id = 9,
                    ApplicantId = 5,
                    ExamId = 3,
                    Score = 98.0
                },

                     new()
                {
                    Id = 10,
                    ApplicantId = 6,
                    ExamId = 1,
                    Score = 85.0
                },

                      new()
                {
                    Id = 10,
                    ApplicantId = 6,
                    ExamId = 3,
                    Score = 48.0
                }
            };

            // Инициализация списка заявлений
            Applications = new List<Application>
            {
                new() 
                { 
                    Id = 1, 
                    ApplicantId = 1, 
                    SpecialtyCode = "01.01.01", 
                    Priority = 1 
                },

                new() 
                { 
                    Id = 2, 
                    ApplicantId = 1, 
                    SpecialtyCode = "02.02.02", 
                    Priority = 2 
                },

                new() 
                { 
                    Id = 3, 
                    ApplicantId = 2, 
                    SpecialtyCode = "03.03.03", 
                    Priority = 1 
                },

                new() 
                { 
                    Id = 4, 
                    ApplicantId = 2, 
                    SpecialtyCode = "01.01.01", 
                    Priority = 2 
                },

                new() 
                { 
                    Id = 5, 
                    ApplicantId = 3, 
                    SpecialtyCode = "02.02.02", 
                    Priority = 1 
                },

                new()
                {
                    Id = 6,
                    ApplicantId = 4,
                    SpecialtyCode = "02.02.02",
                    Priority = 1
                },

                 new()
                {
                    Id = 7,
                    ApplicantId = 4,
                    SpecialtyCode = "01.01.01",
                    Priority = 2
                },

                  new()
                {
                    Id = 8,
                    ApplicantId = 5,
                    SpecialtyCode = "02.02.02",
                    Priority = 1
                },

                   new()
                {
                    Id = 9,
                    ApplicantId = 6,
                    SpecialtyCode = "03.03.03",
                    Priority = 1
                },
            };
        }
    }
}
