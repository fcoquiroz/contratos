using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace scontracts.Shared.DTO
{
    /// <summary>
    /// Constants
    /// </summary>
    public class Constants
    {
      
        //private const string endpoint = "https://scontractsapi.azurewebsites.net/api";

        //Ruta local
        //private const string endpoint = "https://localhost:444/api";
        private const string endpoint = "/api";
        /// <summary>
        /// ctoScheme
        /// </summary>
        public const string ctoScheme = "CtoKey";

        /// <summary>
        /// Asunto
        /// </summary>
        public const string Asunto = "Solicitud de Contrato";

        /// <summary>
        /// ID_Correo
        /// </summary>
        public const int ID_Correo = 1;
        #region AUTH

        /// <summary>
        /// api_auth_authenticateUser
        /// </summary>
        public const string api_auth_authenticateUser = endpoint + "/Auth/authenticate-user";


        /// <summary>
        /// api_auth_getByUserAccessToken
        /// </summary>
        public const string api_auth_getByUserAccessToken = endpoint + "/Auth/user-bytoken";


        /// <summary>
        /// api_auth_getUserByName
        /// </summary>
        public const string api_auth_getUserByName = endpoint + "/Auth/user-byname";


        /// <summary>
        /// api_auth_refreshToken
        /// </summary>
        public const string api_auth_refreshToken = endpoint + "/Auth/refresh-user-token";

        /// <summary>
        /// api_request_data
        /// </summary>
        public const string api_log = endpoint + "/Contract/Log";


        #endregion

        #region Contracts
        /// <summary>
        /// api_contract_fileUpload
        /// </summary>
        public const string api_contract_fileUpload = endpoint + "/contract/file-upload";

        /// <summary>
        /// api_contract_create | api_contract_get
        /// </summary>
        public const string api_contracts = endpoint + "/Contract/contracts";


        /// <summary>
        /// api_contract_create
        /// </summary>
        public const string api_contract_create = endpoint + "/contract/contracts";
        /// <summary>
        /// api_contracts_data
        /// </summary>
        public const string api_contracts_data = endpoint + "/Contract/contracts-data/";

        /// <summary>
        /// api_contracts_data
        /// </summary>
        public const string api_tracing_data = endpoint + "/Contract/Tracing";
        /// <summary>
        /// api_accept_cover
        /// </summary>
        public const string api_accept_cover = endpoint + "/contract/acceptCover";
        /// <summary>
        /// api_reject_cover
        /// </summary>
        public const string api_reject_cover = endpoint + "/contract/rejectCover";
        /// <summary>
        /// api_management_commentary
        /// </summary>
        public const string api_management_commentary = endpoint + "/contract/managementCommentary";
        /// <summary>
        /// api_request_data
        /// </summary>
        public const string api_request_data = endpoint + "/Contract/request";
        /// <summary>
        /// api_status_data
        /// </summary>
        public const string api_status_data = endpoint + "/Contract/status";


        /// <summary>
        /// api_contract_create | api_contract_get
        /// </summary>
        public const string api_contracts_parent = endpoint + "/Contract/parentContracts";

        /// <summary>
        /// api_related_contracts
        /// </summary>
        public const string api_related_contracts = endpoint + "/Contract/relatedContracts";

        /// <summary>
        /// api_related_contracts
        /// </summary>
        public const string api_released_docs = endpoint + "/Contract/releasedDocs";

        /// <summary>
        /// api_cover_data_get
        /// </summary>
        public const string api_cover_data_get = endpoint + "/Contract/coverDataGet";
        /// <summary>
        /// api_related_contracts
        /// </summary>
        public const string api_template_doc = endpoint + "/Contract/templateDocs";

        /// <summary>
        /// api_management_cover
        /// </summary>
        public const string api_management_cover = endpoint + "/Contract/managementCover";

        /// <summary>
        /// api_token_caratula
        /// </summary>
        public const string api_User_token =  "/token";

        /// <summary>
        /// MakeCaratulas
        /// </summary>
        public const string api_Make_Caratulas = endpoint +  "/MakeCaratulas";

        /// <summary>
        /// MakeCaratulas
        /// </summary>
        public const string api_Generar_Reporte = endpoint + "/Reporte";

        /// <summary>
        /// MakeCaratulas
        /// </summary>
        public const string api_Generar_Reporte_Liberado = endpoint + "/ReporteLiberado";

        /// <summary>
        /// api_Listado_idiomas
        /// </summary>
        public const string api_Listado_idiomas = endpoint + "/ListaIdiomas";
        #endregion

        #region Nombre de Estatus
        /// <summary>
        /// PendienteAutorizacion
        /// </summary>
        public const string PendienteAutorizacion = "Pendiente de Autorización ";
        /// <summary>
        /// EnRevisionSolicitante
        /// </summary>
        public const string EnRevisionSolicitante  = "En Revisión Solicitante ";
        /// <summary>
        /// ContratosRevisionJuridico
        /// </summary>
        public const string ContratosRevisionJuridico = "Contratos revisión Jurídico ";
        /// <summary>
        /// EnParo
        /// </summary>
        public const string EnParo = "En Paro ";
        /// <summary>
        /// Entregado
        /// </summary>
        public const string Entregado = "Entregado ";
        /// <summary>
        /// Borrador
        /// </summary>
        public const string Borrador = "Borrador";
        /// <summary>
        /// PendienteAutorizacion100
        /// </summary>
        public const string PendienteAutorizacion100 = "Estatus Pendiente de autorización 100 ";
        /// <summary>
        /// PendienteAutorizacion200
        /// </summary>
        public const string PendienteAutorizacion200 = "Estatus Pendiente de autorización 200 ";
        /// <summary>
        /// RevisioSolicitante
        /// </summary>
        public const string RevisioSolicitante = "En Revisión Solicitante ";
        /// <summary>
        /// ElaboracionRevJuridico
        /// </summary>
        public const string ElaboracionRevJuridico = "Elaboración/Revisión por Jurídico ";
        /// <summary>
        /// RevComentariosJuridico
        /// </summary>
        public const string RevComentariosJuridico = "Revisión de Comentarios por Jurídico ";
        /// <summary>
        /// AutorizadoSolicitante
        /// </summary>
        public const string AutorizadoSolicitante = "Contrato Autorizado por Solicitante ";
        /// <summary>
        /// PreparacionFirma
        /// </summary>
        public const string PreparacionFirma = "Preparación Originales Para Firma ";
        /// <summary>
        /// StandBy
        /// </summary>
        public const string StandBy = "Stand By ";
        /// <summary>
        /// EnEsperaReplica
        /// </summary>
        public const string EnEsperaReplica = "En Espera de Replica ";
        /// <summary>
        /// EsperaDocumentacion
        /// </summary>
        public const string EsperaDocumentacion = "Espera Documentación y/o Información ";
        /// <summary>
        /// EntregadoFirma
        /// </summary>
        public const string EntregadoFirma = "Entregado Para Firma ";
        /// <summary>
        /// EntregadoCorreo
        /// </summary>
        public const string EntregadoCorreo = "Entregado por Correo para Firma ";
        /// <summary>
        /// EsperaCaratulaValidacion
        /// </summary>
        public const string EsperaCaratulaValidacion = "Espera de carátula de validación ";
        /// <summary>
        /// EsperaCaratulaValidacion
        /// </summary>
        public const string RevisionAbogado = "Revisión por el Abogado ";
        /// <summary>
        /// 
        /// </summary>
        public const string EsperaCaratulaValidacionAut = "Espera de carátula de validación por Autorizadores ";
        #endregion
    }
}
