using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Repository.Core.Domain
{
    public class TB_Relacion_Formato_Unidad
    {
        public int ID_Relacion { get; set; }
        public int ID_FormatoLiberado { get; set; }
        public int ID_UnidadUsuario { get; set; }
        public bool Activo { get; set; }
    }
}
