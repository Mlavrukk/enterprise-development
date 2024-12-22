using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace UniversityAdmission.Domain.Entities
{
    /// <summary>
    /// �������
    /// </summary>
    [Table("exam")]
    public class Exam
    {
        /// <summary>
        /// ������������� ��������
        /// </summary>
        public required int Id { get; set; }

        /// <summary>
        /// �������� ��������
        /// </summary>
        public required string Name { get; set; }

        /// <summary>
        /// ���������� ��������� ������������
        /// </summary>
        public ICollection<ExamResult> ExamResults { get; set; }
    }
}