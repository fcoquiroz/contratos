using System;
using System.Collections.Generic;
using System.Text;

namespace scontracts.Shared.DTO
{
    public class TipoSolicitudDTO
    {
        public int IdTipoSolicitud { get; set; }
        public string Descripcion { get; set; }
        public bool Activo { get; set; }
    }
}
