using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Repository.Core.Domain
{
    public class TB_Campos_Caratula
    {
        public int Id_Campo { get; set; }
        public Nullable<int> Id_Caratula { get; set; }
        public string KeyCampo { get; set; }
        public string NombreCampo { get; set; }
        public bool? Activo { get; set; }
        public int? IdConstante { get; set; }
    }
}
