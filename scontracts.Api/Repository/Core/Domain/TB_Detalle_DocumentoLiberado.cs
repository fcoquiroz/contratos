using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Repository.Core.Domain
{
    public class TB_Detalle_DocumentoLiberado
    {
        public int ID_Detalle { get; set; }
        public long ID_Contrato { get; set; }
        public int ID_Campo { get; set; }
        public string Valor { get; set; }
        public bool Activo { get; set; }
        
    }
}
