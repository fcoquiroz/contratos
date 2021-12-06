using System;
using System.Collections.Generic;
using System.Text;

namespace scontracts.Shared.DTO
{
    public class CargarSolicitudContratoDTO
    {
        public string Folio { get; set; }
        public string Prioridad { get; set; }
        public string Solicitante { get; set; }
        public string PuestoSolicitante { get; set; }
        public string UnidadSolicitante { get; set; }
        public string Juridico { get; set; }
        public string JuridicoCorreo { get; set; }
        public string Responsable { get; set; }
        public string PuestoResponsable { get; set; }
        public string TelResponsable { get; set; }
        public string UnidadResponsable { get; set; }
        public string TipoDocumento { get; set; }
        public string EmpresaContrato { get; set; }
        public string Contraparte { get; set; }
        public string ObjetoNegociacion { get; set; }
        public string DescServiciosProductos { get; set; }
        public string Contraprestacion { get; set; }
        public string FormaPago { get; set; }
        public string Vigencia { get; set; }
        public string LugarFechaFirma { get; set; }
        public string CondicionesEspeciales { get; set; }
        public int Acta { get; set; }
        public int Poder { get; set; }
        public int Comprobante { get; set; }
        public int Identificacion { get; set; }
        public int Cedula { get; set; }
        public int Version { get; set; }
        public int Titulo { get; set; }
        public int Otros { get; set; }
        public string Moneda { get; set; }
        public string Idioma { get; set; }
        public string FechaSol { get; set; }
        public string FechaVen { get; set; }
        public int Estatus { get; set; }
    }
}
