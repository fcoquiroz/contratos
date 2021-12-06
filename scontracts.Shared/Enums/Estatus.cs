using System;
using System.Collections.Generic;
using System.Text;

namespace scontracts.Shared.Enums
{
    /// <summary>
    /// EstatusSolicititante
    /// </summary>
    public enum EstatusSolicitud
    {
        Borrador = 99,
        PendienteDeAutorizacionA = 100,
        PendienteDeAutorizacionB = 200,
        ElaboracionRevisionJuridico = 300,
        EnRevisionSolicitante = 400,
        RevisionComentariosJuridico = 500,
        ContratoAutorizadoSolicitante = 600,
        PreparacionOriginalesParaFirma = 700,
        EntregadoParaFirma = 800,
        Archivado = 900,
        Cancelado = 1000,
        EsperaDocumentacionInformacion = 1100,
        StandBy = 1200,
        Rechazado = 1300,
        EntregadoPorCorreoParaFirma = 1400,
        Liberado = 1500,
        Eliminado = 1600,
        EnEsperaDeReplica = 1700,
        EnEsperaDeCaratulaValidacion = 1800,
        RevisionPorelAbogado = 1900,
        CaratulaRevisionAutorizadores = 2000,
        Reactivar = 6000
    }
}
