using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Repository.Core.Domain
{
    public class Cat_FormatoLiberados
    {
        public int ID_FormatoLiberado { get; set; }
        public string Nombre { get; set; }
        public bool Activo { get; set; }
        public DateTime? FechaRegistro { get; set; }
        public DateTime? FechaModifico { get; set; }
        public string Plantilla { get; set; }
        public int? Id_TipoDocumento { get; set; }
        public int? Id_TipoSolicitud { get; set; }
    }
}
