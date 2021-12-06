using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Repository.Core.Domain
{
    public class TB_MultiProducto
    {
        public int ID_MultiProducto { get; set; }
        public long ID_Contrato { get; set; }
        public int? ID_Producto { get; set; }
        public bool? Activo { get; set; }
    }
}
