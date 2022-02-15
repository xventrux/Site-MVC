using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Site.Models.Entities.Base
{
    /// <summary>
    /// Базовая сущность
    /// </summary>
    public class EntityBase
    {
        /// <summary>
        /// Идентификатор сущности
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Дата создания сущности
        /// </summary>
        public DateTime CreatingDate { get; set; }

        /// <summary>
        /// Дата удаления сущности
        /// </summary>
        public DateTime UpdateDate { get; set; }
    }
}
