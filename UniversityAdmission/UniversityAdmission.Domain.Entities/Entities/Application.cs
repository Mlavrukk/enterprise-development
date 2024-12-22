using System.ComponentModel.DataAnnotations.Schema;

namespace UniversityAdmission.Domain.Entities
{
    /// <summary>
    /// Заявление абитуриента на специальность
    /// </summary>
    [Table("application")]
    public class Application
    {
        /// <summary>
        /// Идентификатор заявления
        /// </summary>
        public required int Id { get; set; }

        /// <summary>
        /// Идентификатор абитуриента
        /// </summary>
        public required int ApplicantId { get; set; }

        /// <summary>
        /// Идентификатор специальности
        /// </summary>
        public required string SpecialtyCode { get; set; }

        /// <summary>
        /// Приоритет специальности
        /// </summary>
        public required int Priority { get; set; }
    }
}