using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Repository.Core.Domain
{
    /// <summary>
    /// TB_Contratos_Email
    /// </summary>
    public class TB_Contratos_Email
    {
        /// <summary>
        /// ID_Contrato_Email
        /// </summary>
        public long ID_Contrato_Email { get; set; }
        /// <summary>
        /// ID_Correo
        /// </summary>
        public int? ID_Correo { get; set; }
        /// <summary>
        /// ID_Contrato
        /// </summary>
        public long ID_Contrato { get; set; }
        /// <summary>
        /// Asunto
        /// </summary>
        public string Asunto { get; set; }
        /// <summary>
        /// Body
        /// </summary>
        public string Body { get; set; }
        /// <summary>
        /// Destinatarios
        /// </summary>
        public string Destinatarios { get; set; }
        /// <summary>
        /// Attachment
        /// </summary>
        public string Attachment { get; set; }
        /// <summary>
        /// FechaGeneroCorreo
        /// </summary>
        public DateTime? FechaGeneroCorreo { get; set; }
        /// <summary>
        /// FechaEnvio
        /// </summary>
        public DateTime? FechaEnvio { get; set; }
        /// <summary>
        /// Enviado
        /// </summary>
        public bool Enviado { get; set; }
    }
}
