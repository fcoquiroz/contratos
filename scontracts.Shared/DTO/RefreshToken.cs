using System;
using System.Collections.Generic;
using System.Text;

namespace scontracts.Shared.DTO
{
    /// <summary>
    /// RefreshTokenDTO
    /// </summary>
    public class RefreshTokenDTO
    {
        /// <summary>
        /// TokenId
        /// </summary>
        public int TokenId { get; set; }
        /// <summary>
        /// UserId
        /// </summary>
        public int UserId { get; set; }
        /// <summary>
        /// Token
        /// </summary>
        public string Token { get; set; }
        /// <summary>
        /// ExpiryDate
        /// </summary>
        public DateTime ExpiryDate { get; set; }

    }
}
