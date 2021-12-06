using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace scontracts.Api.Models
{
    public class FileSaveRequest
    {
        public long id_contrato { get; set; } 
        public String is_rev { get; set; }
        public List<IFormFile> files { get; set; }
    }
}
