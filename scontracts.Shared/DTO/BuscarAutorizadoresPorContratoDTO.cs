using System;
using System.Collections.Generic;
using System.Text;

namespace scontracts.Shared.DTO
{
    public class BuscarAutorizadoresPorContratoDTO
    {
        public int? Id_Autorizador { get; set; }
        public string Nombre { get; set; }
        public string Correo { get; set; }
        public string TipoAutorizador { get; set; }
        public string TipoCaratula { get; set; }
        public string Producto { get; set; }
        public string Pais { get; set; }
        public int? IDProducto { get; set; }
        public int? IDPais { get; set; }
        public int? IDTipoAut { get; set; }
        public int? idTipoCaratula { get; set; }
        public int Extra { get; set; }
        public int? idUsuario { get; set; }
    }
}
