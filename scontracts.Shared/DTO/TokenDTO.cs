using System;
using System.Collections.Generic;
using System.Text;

namespace scontracts.Shared.DTO
{
    /// <summary>
    /// TokenDTO
    /// </summary>
    public class TokenDTO
    {
        /// <summary>
        /// access_token
        /// </summary>
        public string access_token { get; set; }
        /// <summary>
        /// expires_in
        /// </summary>
        public int expires_in { get; set; }
    }
}
