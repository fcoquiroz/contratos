using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Repository.Core.Domain
{
    /// <summary>
    /// TB_Autorizadores_Contrato
    /// </summary>
    public class TB_Autorizadores_Contrato
    {
        /// <summary>
        /// IDAutorizadoresContrato
        /// </summary>
        public int IDAutorizadoresContrato { get; set; }
        /// <summary>
        /// ID_Contrato
        /// </summary>
        public long ID_Contrato { get; set; }
        /// <summary>
        /// Id_Autorizador
        /// </summary>
        public int? Id_Autorizador { get; set; }
        /// <summary>
        /// Extra
        /// </summary>
        public bool? Extra { get; set; }
        /// <summary>
        /// Activo
        /// </summary>
        public bool? Activo { get; set; }
    }
}
