using System.ComponentModel.DataAnnotations.Schema;

namespace UniversityAdmission.UniversityAdmission.Domain.Entities
{
    /// <summary>
    /// ��������� �������� �����������
    /// </summary>
    [Table("exam_result")]
    public class ExamResult
    {
        /// <summary>
        /// ������������� ����������
        /// </summary>
        public required int Id { get; set; }

        /// <summary>
        /// ������������� �����������
        /// </summary>
        public required int ApplicantId { get; set; }

        /// <summary>
        /// ������������� ��������
        /// </summary>
        public required int ExamId { get; set; }

        /// <summary>
        /// ����� ����������� �� ��������
        /// </summary>
        public required double Score { get; set; }
    }
}