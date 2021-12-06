using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Repository.Core.Domain
{
    /// <summary>
    /// ID_Parametro
    /// </summary>
    public class TB_Parametros
    {
        /// <summary>
        /// ID_Parametro
        /// </summary>
        public int ID_Parametro { get; set; }
        /// <summary>
        /// Parametro
        /// </summary>
        public string Parametro { get; set; }
        /// <summary>
        /// Valor
        /// </summary>
        public string Valor { get; set; }
        /// <summary>
        /// TipoParametros
        /// </summary>
        public string TipoParametros { get; set; }
    }
}
