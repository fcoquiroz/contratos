using System;
using System.Collections.Generic;
using System.Text;

namespace scontracts.Shared.DTO
{
    /// <summary>
    /// CoverDTO
    /// </summary>
    public class CoverDTO
    {
        /// <summary>
        /// ID_Contrato
        /// </summary>
        public long ID_Contrato { get; set; }
        public bool AutorizadoPorTodos { get; set; }
        public string NombreAutorizador { get; set; }
        public int TipoAutorizador { get; set; }
        public int B_Business { get; set; }
        public int B_Tecnico_Operativo { get; set; }
        public int B_Comercial { get; set; }
        public bool ExisteAutorizacion { get; set; }
        public bool? Autorizo { get; set; }
        public bool? ExisteRechazo { get; set; }

 
    }
    public class CoverDataGetDTO
    { 
        public int Id_Campo { get; set; }
        public int? Id_Caratula { get; set; }
        public string KeyCampo { get; set; }
        public string NombreCampo { get; set; }
        public bool? Activo { get; set; }
        public int? IdConstante { get; set; }
    }
    public class CoverDetalleDataGetDTO
    {
        public int Id_Detalle_Caratula { get; set; }
        public int Id_Contrato { get; set; }
        public int? Id_Campo { get; set; }
        public string Valor { get; set; }
    }
}
