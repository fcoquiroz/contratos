using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Repository.Core.Domain
{
    public class Cat_TipoSolicitud
    {
        public int IdTipoSolicitud { get; set; }
        public string Descripcion { get; set; }
        public bool Activo { get; set; }
    }
}
