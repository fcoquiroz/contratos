using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Repository.Core.Domain
{
    /// <summary>
    /// TB_Contratos_Seguimiento
    /// </summary>
    public class TB_Contratos_Seguimiento
    {
        /// <summary>
        /// ID_Contrato_Seguimiento
        /// </summary>
        public long ID_Contrato_Seguimiento { get; set; }
        /// <summary>
        /// ID_Contrato
        /// </summary>
        public long ID_Contrato { get; set; }
        /// <summary>
        /// DiasEstimados
        /// </summary>
        public int DiasEstimados { get; set; }
        /// <summary>
        /// DiasReales
        /// </summary>
        public int DiasReales { get; set; }
        /// <summary>
        /// DiasAdelanto
        /// </summary>
        public int DiasAdelanto { get; set; }
        /// <summary>
        /// DiasRetraso
        /// </summary>
        public int DiasRetraso { get; set; }
        /// <summary>
        /// FechaEnvioContrato
        /// </summary>
        public DateTime FechaEnvioContrato { get; set; }
        /// <summary>
        /// FechaInicio
        /// </summary>
        public DateTime FechaInicio { get; set; }
        /// <summary>
        /// FechaVencimiento
        /// </summary>
        public DateTime FechaVencimiento { get; set; }
        /// <summary>
        /// CreateDate
        /// </summary>
        public DateTime CreateDate { get; set; }
        /// <summary>
        /// ReCalculado
        /// </summary>
        public bool ReCalculado { get; set; }
    }
}
