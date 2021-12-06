using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Repository.Core.Domain
{
    /// <summary>
    /// TB_Contratos_Appointment
    /// </summary>
    public class TB_Contratos_Appointment
    {
        /// <summary>
        /// ID_Contrato_Appointment
        /// </summary>
        public long ID_Contrato_Appointment { get; set; }
        /// <summary>
        /// ID_Appointment
        /// </summary>
        public string ID_Appointment { get; set; }
        /// <summary>
        /// ID_Contrato
        /// </summary>
        public long ID_Contrato { get; set; }
        /// <summary>
        /// Create_Date
        /// </summary>
        public DateTime Create_Date { get; set; }
        /// <summary>
        /// Modify_Date
        /// </summary>
        public DateTime Modify_Date { get; set; }
    }
}
