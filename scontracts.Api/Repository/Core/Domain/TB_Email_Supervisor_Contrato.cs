using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Repository.Core.Domain
{
    public class TB_Email_Supervisor_Contrato
    {
        public long ID_CorreoSupervisor { get; set; }
        public long ID_Contrato { get; set; }
        public string Email { get; set; }
        public bool? Activo { get; set; }
    }
}
