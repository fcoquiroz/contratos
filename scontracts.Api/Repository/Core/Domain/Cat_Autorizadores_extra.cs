using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Repository.Core.Domain
{
    /// <summary>
    /// Cat_Autorizadores_extra
    /// </summary>
    public class Cat_Autorizadores_extra
    {
        /// <summary>
        /// Id_Autorizador_extra
        /// </summary>
        public int Id_Autorizador_extra { get; set; }
        /// <summary>
        /// Nombre
        /// </summary>
        public string Nombre { get; set; }
        /// <summary>
        /// Correo
        /// </summary>
        public string Correo { get; set; }
        /// <summary>
        /// Activo
        /// </summary>
        public bool? Activo { get; set; }
        /// <summary>
        /// TipoAutorizador
        /// </summary>
        public int TipoAutorizador { get; set; }
        /// <summary>
        /// TipoCaratula
        /// </summary>
        public int TipoCaratula { get; set; }
        /// <summary>
        /// ID_Contrato
        /// </summary>
        public long ID_Contrato { get; set; }
        /// <summary>
        /// ID_Usuario
        /// </summary>
        public int ID_Usuario { get; set; }
        /// <summary>
        /// ID_Pais
        /// </summary>
        public int ID_Pais { get; set; }
        /// <summary>
        /// ID_Producto
        /// </summary>
        public int ID_Producto { get; set; }
    }
}
