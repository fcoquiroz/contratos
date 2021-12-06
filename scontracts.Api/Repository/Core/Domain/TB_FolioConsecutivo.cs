using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Repository.Core.Domain
{
    /// <summary>
    /// TB_FolioConsecutivo
    /// </summary>
    public class TB_FolioConsecutivo
    {
        /// <summary>
        /// IdFolioConsecutivo
        /// </summary>
        public int IdFolioConsecutivo { get; set; }
        /// <summary>
        /// IdConsecutivo
        /// </summary>
        public long IdConsecutivo { get; set; }
        /// <summary>
        /// Ano
        /// </summary>
        public long Ano { get; set; }
        /// <summary>
        /// ID_TipoSolicitud
        /// </summary>
        public int ID_TipoSolicitud { get; set; }
    }
}
