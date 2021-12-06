using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Repository.Core.Domain
{
    /// <summary>
    /// RefreshToken
    /// </summary>
    public class RefreshToken
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
