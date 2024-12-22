using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using static System.Net.Mime.MediaTypeNames;

namespace UniversityAdmission.Domain.Entities
{
    /// <summary>
    /// ����������
    /// </summary>
    [Table("applicant")]
    public class Applicant
    {
        /// <summary>
        /// ������������� �����������
        /// </summary>
        public required int Id { get; set; }

        /// <summary>
        /// ��� �����������
        /// </summary>
        public required string FullName { get; set; }

        /// <summary>
        /// ���� �������� �����������
        /// </summary>
        public required DateTime DateOfBirth { get; set; }

        /// <summary>
        /// ������ �����������
        /// </summary>
        public required string Country { get; set; }

        /// <summary>
        /// ����� �����������
        /// </summary>
        public required string City { get; set; }

        /// <summary>
        /// ���������� ��������� �����������
        /// </summary>
        public ICollection<ExamResult> ExamResults { get; set; }

        /// <summary>
        /// ��������� �� �������������
        /// </summary>
        public ICollection<Application> Applications { get; set; }
    }
}