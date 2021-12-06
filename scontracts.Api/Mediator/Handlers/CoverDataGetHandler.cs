using Api.Mediator.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.WebUtilities;
using Repository.Persistence;
using RepositorySP.Persistence;
using scontracts.Api.Context;
using scontracts.Api.Context.Strategies;
using scontracts.Api.Helpers;
using scontracts.Api.Mediator.Commands;
using scontracts.Shared.DTO;
using scontracts.Shared.Requests;
using scontracts.Shared.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace scontracts.Api.Mediator.Handlers
{
    public class CoverDataGetHandler : IRequestHandler<CoverDataGetQuery, ResponseT<CoverDataGetResponse>>
    {
        public async Task<ResponseT<CoverDataGetResponse>> Handle(CoverDataGetQuery request, CancellationToken cancellationToken)
        {
            ResponseT<CoverDataGetResponse> res = new ResponseT<CoverDataGetResponse>();
            try
            {
                
                List<BuscarAutorizadoresPorContratoDTO> ListBuscarAutorizadoresPorContrato = new List<BuscarAutorizadoresPorContratoDTO>();
                int? ID_Pais_Ref = 0, ID_TipoCaratula_Ref = 0;
              
                #region Log
                try
                {
                    LogCreateRequest requestLog = new LogCreateRequest
                    {
                        UserName = request.ID_Usuario_Envio.ToString(),
                        Path = "AuthorizeCaratula.cshtml",
                        Control = "Contract/CoverDataGet",
                        Message = "Consulta de Caratula"
                    };
                    var commands = new LogCreateCommand(requestLog);
                    new ContractContext(new ContractLogginData()).SaveLog(commands);
                }
                catch (Exception ex)
                {
                    ErrorLogFile.LogCritical(ex.Message);
                }
                #endregion

                await using (var unitofworkSP = new RepositorySP.Persistence.UnitOfWork(new DataSPContext()))
                {
                    ListBuscarAutorizadoresPorContrato = await unitofworkSP.ContractRepo.BuscarAutorizadoresPorContrato(request.ID_Contrato);
                }


                using (var unitofwork = new Repository.Persistence.UnitOfWork(new DataContext()))
                {

                    unitofwork.TB_ContratosRoutines.ObtenerPaisTipoSolicitud(request.ID_Contrato, ref ID_Pais_Ref, ref ID_TipoCaratula_Ref);

                    res.update(StatusCodes.Status200OK, ReasonPhrases.GetReasonPhrase(StatusCodes.Status200OK),
                 new CoverDataGetResponse
                 {
                     ObtenerCamposCaratula = unitofwork.TB_Campos_CaratulaRoutines.ObtenerCamposCaratula(request.ID_Contrato),
                     ObtenerDetalleCaratula = unitofwork.TB_Detalle_CaratulaRoutines.ObtenerDetalleCaratula(request.ID_Contrato),
                     ListBuscarAutorizadoresPorContrato = ListBuscarAutorizadoresPorContrato,
                     idNuevo = unitofwork.Cat_Autorizadores_extraRoutines.ObtenerAutorizadorNuevo(),
                     ListUsuario = unitofwork.Cat_UsuarioRoutines.ObtenerUsuarios(),
                     ObtenerTipoAutorizador = unitofwork.Cat_TipoAutorizadorRoutines.ObtenerTipoAutorizador(),
                     ListaPaises = unitofwork.Cat_PaisRoutines.ObtenerPaises(),
                     ListaTipoContraparte = unitofwork.Cat_TipoSolicitudRoutines.ObtenerTipoContraparte(),
                     ListaProductos = unitofwork.TB_MultiProductoRoutines.ObtenerMultiProductoParaCorreoAutorizador(request.ID_Contrato),
                     ID_Pais = ID_Pais_Ref,
                     ID_TipoCaratula = ID_TipoCaratula_Ref

                 }) ;

                }
            }
            catch (Exception ex)
            {

                ErrorLogFile.LogCritical(ex.Message);
                res.update(StatusCodes.Status500InternalServerError, ex.Message, new CoverDataGetResponse());
            }
            return res;
        }
    }
}
