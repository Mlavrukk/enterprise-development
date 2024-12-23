using System.ComponentModel.DataAnnotations.Schema;

namespace UniversityAdmission.UniversityAdmission.Domain.Entities
{
    /// <summary>
    /// Результат экзамена абитуриента
    /// </summary>
    [Table("exam_result")]
    public class ExamResult
    {
        /// <summary>
        /// Идентификатор результата
        /// </summary>
        public required int Id { get; set; }

        /// <summary>
        /// Идентификатор абитуриента
        /// </summary>
        public required int ApplicantId { get; set; }

        /// <summary>
        /// Идентификатор экзамена
        /// </summary>
        public required int ExamId { get; set; }

        /// <summary>
        /// Баллы абитуриента на экзамене
        /// </summary>
        public required double Score { get; set; }
    }
}