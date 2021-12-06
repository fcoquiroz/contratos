using System;
using System.Collections.Generic;
using System.Text;

namespace scontracts.Shared.Responses
{
    /// <summary>
    /// ProfileFindResponse
    /// </summary>
    public class ProfileFindResponse
    {
        /// <summary>
        /// ProfileId 
        /// </summary>
        public int ProfileId { get; set; }
        /// <summary>
        /// ProfileName
        /// </summary>
        public string ProfileName { get; set; }
        /// <summary>
        /// Active
        /// </summary>
        public bool Active { get; set; }



    }
}
