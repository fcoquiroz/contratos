using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Repository.Core.Domain
{
    /// <summary>
    /// TB_Contratos_Detalle
    /// </summary>
    public class TB_Contratos_Detalle
    {
        /// <summary>
        /// ID_Contrato_Detalle
        /// </summary>
        public long ID_Contrato_Detalle { get; set; }
        /// <summary>
        /// ID_Contrato
        /// </summary>
        public long ID_Contrato { get; set; }
        /// <summary>
        /// ObjetoNegociacion
        /// </summary>
        public string ObjetoNegociacion { get; set; }
        /// <summary>
        /// DescServiciosProductos
        /// </summary>
        public string DescServiciosProductos { get; set; }
        /// <summary>
        /// Contraprestacion
        /// </summary>
        public string Contraprestacion { get; set; }
        /// <summary>
        /// FormaPago
        /// </summary>
        public string FormaPago { get; set; }
        /// <summary>
        /// Vigencia
        /// </summary>
        public string Vigencia { get; set; }
        /// <summary>
        /// LugarFechaFirma
        /// </summary>
        public string LugarFechaFirma { get; set; }
        /// <summary>
        /// CondicionesEspeciales
        /// </summary>
        public string CondicionesEspeciales { get; set; }
        /// <summary>
        /// ImporteTotalContrato
        /// </summary>
        public decimal? ImporteTotalContrato { get; set; }
    }
}
