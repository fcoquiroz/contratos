using System;
using System.Collections.Generic;
using System.Text;

namespace scontracts.Shared.Requests
{
    public class CoverDataGetRequest
    {  /// <summary>
            /// ID_Contrato
            /// </summary>
            public int ID_Contrato { get; set; }
        //public int IdTipoSolicitud { get; set; }
        /////// <summary>
        /////// Folio
        /////// </summary>
        ////public string Folio { get; set; }
        /////// <summary>
        /////// ID_Estatus
        /////// </summary>
        ////public int ID_Estatus { get; set; }
        ///// <summary>
        ///// ID_Usuario_Envio
        ///// </summary>
        public int ID_Usuario_Envio { get; set; }
        //public int ID_Campo { get; set; }

    }
}
