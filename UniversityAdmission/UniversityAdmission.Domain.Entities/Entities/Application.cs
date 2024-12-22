using System.ComponentModel.DataAnnotations.Schema;

namespace UniversityAdmission.Domain.Entities
{
    /// <summary>
    /// ��������� ����������� �� �������������
    /// </summary>
    [Table("application")]
    public class Application
    {
        /// <summary>
        /// ������������� ���������
        /// </summary>
        public required int Id { get; set; }

        /// <summary>
        /// ������������� �����������
        /// </summary>
        public required int ApplicantId { get; set; }

        /// <summary>
        /// ������������� �������������
        /// </summary>
        public required string SpecialtyCode { get; set; }

        /// <summary>
        /// ��������� �������������
        /// </summary>
        public required int Priority { get; set; }
    }
}