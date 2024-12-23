using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using static System.Net.Mime.MediaTypeNames;

namespace UniversityAdmission.UniversityAdmission.Domain.Entities
{
    /// <summary>
    /// Специальность
    /// </summary>
    [Table("specialty")]
    public class Specialty
    {
        /// <summary>
        /// Шифр специальности
        /// </summary>
        public required string Code { get; set; }

        /// <summary>
        /// Название специальности
        /// </summary>
        public required string Name { get; set; }

        /// <summary>
        /// Факультет
        /// </summary>
        public required string Faculty { get; set; }

        /// <summary>
        /// Заявления на данную специальность
        /// </summary>
        public ICollection<Application> Applications { get; set; }
    }
}