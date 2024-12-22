using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace UniversityAdmission.Domain.Entities
{
    /// <summary>
    /// Экзамен
    /// </summary>
    [Table("exam")]
    public class Exam
    {
        /// <summary>
        /// Идентификатор экзамена
        /// </summary>
        public required int Id { get; set; }

        /// <summary>
        /// Название экзамена
        /// </summary>
        public required string Name { get; set; }

        /// <summary>
        /// Результаты экзаменов абитуриентов
        /// </summary>
        public ICollection<ExamResult> ExamResults { get; set; }
    }
}