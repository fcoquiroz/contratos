using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Repository.Core.Domain
{
    public class TB_Detalle_Caratula
    {
        public int Id_Detalle_Caratula { get; set; }
        public int Id_Contrato { get; set; }
        public int? Id_Campo { get; set; }
        public string Valor { get; set; }
    }
}
