using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using static System.Net.Mime.MediaTypeNames;

namespace UniversityAdmission.UniversityAdmission.Domain.Entities
{
    /// <summary>
    /// �������������
    /// </summary>
    [Table("specialty")]
    public class Specialty
    {
        /// <summary>
        /// ���� �������������
        /// </summary>
        public required string Code { get; set; }

        /// <summary>
        /// �������� �������������
        /// </summary>
        public required string Name { get; set; }

        /// <summary>
        /// ���������
        /// </summary>
        public required string Faculty { get; set; }

        /// <summary>
        /// ��������� �� ������ �������������
        /// </summary>
        public ICollection<Application> Applications { get; set; }
    }
}