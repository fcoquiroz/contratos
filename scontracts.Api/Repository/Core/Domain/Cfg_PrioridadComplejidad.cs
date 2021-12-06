using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Repository.Core.Domain
{
    /// <summary>
    /// Cfg_PrioridadComplejidad
    /// </summary>
    public class Cfg_PrioridadComplejidad
    {
        /// <summary>
        /// ID_Prioridad
        /// </summary>
        public int ID_Prioridad { get; set; }
        /// <summary>
        /// ID_TipoContrato
        /// </summary>
        public int ID_TipoContrato { get; set; }
        /// <summary>
        /// Dias
        /// </summary>
        public int Dias { get; set; }
        /// <summary>
        /// Vuelta
        /// </summary>
        public int Vuelta { get; set; }
    }
}
