using System;
using System.Collections.Generic;
using System.Text;

namespace scontracts.Shared.Requests
{
    /// <summary>
    /// LogCreateRequest
    /// </summary>
    public class LogCreateRequest
    {
        #region Log
        /// <summary>
        /// UserName
        /// </summary>
        public string UserName { get; set; }
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
        #endregion
    }
}
