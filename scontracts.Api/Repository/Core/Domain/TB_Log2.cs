using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Repository.Core.Domain
{
    /// <summary>
    /// TB_Log2
    /// </summary>
    public class TB_Log2
    {
        /// <summary>
        /// Id_log
        /// </summary>
        public long Id_log { get; set; }
        /// <summary>
        /// Usuario
        /// </summary>
        public string Usuario { get; set; }
        /// <summary>
        /// Path
        /// </summary>
        public string Path { get; set; }
        /// <summary>
        /// Control
        /// </summary>
        public string Control { get; set; }
        /// <summary>
        /// Message
        /// </summary>
        public string Message { get; set; }
        /// <summary>
        /// Date
        /// </summary>
        public DateTime Date { get; set; }
    }
}
