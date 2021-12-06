using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Repository.Core.Domain
{
    public class TB_Autorizadores_Aut
    {
        public int Id_Autorizadores_Aut { get; set; }
        public int Id_Contrato { get; set; }
        public int Id_Autorizador { get; set; }
        public bool? Autorizo { get; set; }
        public string Comentario { get; set; }
        public DateTime? Fecha { get; set; }
        public bool? EsExtra { get; set; }
        public int Vuelta { get; set; }
    }
}
