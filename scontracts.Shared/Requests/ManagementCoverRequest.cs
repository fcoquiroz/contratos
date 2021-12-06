using System;
using System.Collections.Generic;
using System.Text;

namespace scontracts.Shared.Requests
{
    public class ManagementCoverRequest
    {
        /// <summary>
        /// ID_Contrato
        /// </summary>
        public int ID_Contrato { get; set; }
        /// <summary>
        /// ID_Usuario_Envio
        /// </summary>
        public int ID_Usuario_Envio { get; set; }
        /// <summary>
        /// HfArrayNombre
        /// </summary>
        public string HfArrayNombre { get; set; }
        /// <summary>
        /// Inversion
        /// </summary>
        public string Inversion { get; set; }
        /// <summary>
        /// Capacidad
        /// </summary>
        public string Capacidad { get; set; }
        /// <summary>
        /// Pena
        /// </summary>
        public string Pena { get; set; }
        public string Accion { get; set; }
        public bool? Extra { get; set; }

        /// <summary>
        /// ID_Usuario
        /// </summary>
        public int ID_Usuario { get; set; }

        #region Autorizadores Extra
        /// <summary>
        /// Nombre
        /// </summary>
        public string Nombre { get; set; }
        /// <summary>
        /// Correo
        /// </summary>
        public string Correo { get; set; }
        /// <summary>
        /// tipoAutorizador
        /// </summary>
        public int ID_TipoAutorizador { get; set; }
        /// <summary>
        /// tipoCaratula
        /// </summary>
        public int ID_TipoCaratula { get; set; }
        /// producto
        /// </summary>
        public int ID_Producto { get; set; }
        /// <summary>
        /// pais
        /// </summary>
        public int ID_Pais { get; set; }
        /// <summary>
        /// idAutorizador
        /// </summary>
        public int idAutorizador { get; set; }

        #endregion
        public string Comentarios { get; set; }
    }
}
