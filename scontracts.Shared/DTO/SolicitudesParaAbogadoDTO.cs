using System;
using System.Collections.Generic;
using System.Security.Permissions;
using System.Text;

namespace scontracts.Shared.DTO
{
    public class SolicitudesParaAbogadoDTO
    {

        /// <summary>
        /// Folio
        /// </summary>
        public string Folio { get; set; }
        /// <summary>
        /// Id_Contrato
        /// </summary>
        public long Id_Contrato { get; set; }
        /// <summary>
        /// FechaUltimoMov
        /// </summary>
        public DateTime? FechaUltimoMov { get; set; }
        
        /// Contraparte
        /// </summary>
        public String Contraparte { get; set; }

        /// <summary>
        /// Id_ContratoPadre
        /// </summary>
        public long? Id_ContratoPadre { get; set; }
        /// <summary>
        /// DetalleParaAbogadoDTO
        /// </summary>
        public DetalleParaAbogadoDTO DetalleA { get; set; }
    }
}
