using System;
using System.Collections.Generic;
using System.Text;

namespace scontracts.Shared.DTO
{
    public class CampoContratoLiberadoDTO
    {
        public int Id_Campo { get; set; }
        public int Id_Constante { get; set; }
        public string Valor { get; set; }
        public string Etiqueta { get; set; }
        public string Nombre { get; set; }
    }
}
