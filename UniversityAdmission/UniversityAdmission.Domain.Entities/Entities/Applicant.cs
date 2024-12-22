using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using static System.Net.Mime.MediaTypeNames;

namespace UniversityAdmission.Domain.Entities
{
    /// <summary>
    /// Абитуриент
    /// </summary>
    [Table("applicant")]
    public class Applicant
    {
        /// <summary>
        /// Идентификатор абитуриента
        /// </summary>
        public required int Id { get; set; }

        /// <summary>
        /// ФИО абитуриента
        /// </summary>
        public required string FullName { get; set; }

        /// <summary>
        /// Дата рождения абитуриента
        /// </summary>
        public required DateTime DateOfBirth { get; set; }

        /// <summary>
        /// Страна абитуриента
        /// </summary>
        public required string Country { get; set; }

        /// <summary>
        /// Город абитуриента
        /// </summary>
        public required string City { get; set; }

        /// <summary>
        /// Результаты экзаменов абитуриента
        /// </summary>
        public ICollection<ExamResult> ExamResults { get; set; }

        /// <summary>
        /// Заявления на специальности
        /// </summary>
        public ICollection<Application> Applications { get; set; }
    }
}