using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Repository.Core.Domain
{
    public class Cat_Producto
    {
        public int Id_Producto { get; set; }
        public string Descripcion { get; set; }
        public bool Activo { get; set; }
    }
}
