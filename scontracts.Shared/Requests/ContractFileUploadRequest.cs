using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;

using System.Text;

namespace scontracts.Shared.Requests
{
    /// <summary>
    /// ContractFileUploadRequest
    /// </summary>
    public class ContractFileUploadRequest
    {
        /// <summary>
        /// FilePath
        /// </summary>
        public string FilePath { get; set; }
        /// <summary>
        /// FileExtension
        /// </summary>
        public string FileExtension { get; set; }
        /// <summary>
        /// FileName
        /// </summary>
        public string FileName { get; set; }
        /// <summary>
        /// File
        /// </summary>
        public IFormFile File { get; set; }

    }
}
