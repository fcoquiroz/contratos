using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Repository.Core.Domain
{
    /// <summary>
    /// TB_Historial_Contratos
    /// </summary>
    public class TB_Historial_Contratos
    {
        /// <summary>
        /// ID_HistorialContrato
        /// </summary>
        public long ID_HistorialContrato { get; set; }
        /// <summary>
        /// ID_Estatus
        /// </summary>
        public int ID_Estatus { get; set; }
        /// <summary>
        /// ID_Unidad
        /// </summary>
        public int ID_Unidad { get; set; }
        /// <summary>
        /// ID_Proveedor
        /// </summary>
        public int ID_Proveedor { get; set; }
        /// <summary>
        /// ID_TipoContrato
        /// </summary>
        public int ID_TipoContrato { get; set; }
        /// <summary>
        /// ID_TipoMoneda
        /// </summary>
        public int ID_TipoMoneda { get; set; }
        /// <summary>
        /// ID_Unidad_Usuario
        /// </summary>
        public int ID_Unidad_Usuario { get; set; }
        /// <summary>
        /// ID_ResponsableJuridico
        /// </summary>
        public int ID_ResponsableJuridico { get; set; }
        /// <summary>
        /// Folio
        /// </summary>
        public string Folio { get; set; }
        /// <summary>
        /// FechaSolicitud
        /// </summary>
        public DateTime FechaSolicitud { get; set; }
        /// <summary>
        /// ComentariosEstatus
        /// </summary>
        public string ComentariosEstatus { get; set; }
        /// <summary>
        /// ObjetoContrato
        /// </summary>
        public string ObjetoContrato { get; set; }
        /// <summary>
        /// Solicitante
        /// </summary>
        public string Solicitante { get; set; }
        /// <summary>
        /// FechaVencimientoContrato
        /// </summary>
        public string FechaVencimientoContrato { get; set; }
        /// <summary>
        /// Anio
        /// </summary>
        public int Anio { get; set; }
        /// <summary>
        /// Motivo
        /// </summary>
        public string Motivo { get; set; }
        /// <summary>
        /// FechaAccion
        /// </summary>
        public DateTime FechaAccion { get; set; }
        /// <summary>
        /// ContratoAdjunto
        /// </summary>
        public bool ContratoAdjunto { get; set; }
        /// <summary>
        /// ID_TipoSolicitud
        /// </summary>
        public int ID_TipoSolicitud { get; set; }
        /// <summary>
        /// ValidoJuridico
        /// </summary>
        public bool ValidoJuridico { get; set; }
    }
}
