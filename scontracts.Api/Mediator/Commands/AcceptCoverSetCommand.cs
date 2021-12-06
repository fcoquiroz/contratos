using MediatR;
using scontracts.Shared.Requests;
using scontracts.Shared.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace scontracts.Api.Mediator.Commands
{
    /// <summary>
    /// AcceptCoverSetCommand
    /// </summary>
    public class AcceptCoverSetCommand : AcceptCoverSetRequest, IRequest<ResponseT<AcceptCoverSetResponse>>
    {
        /// <summary>
        /// AcceptCoverSetCommand
        /// </summary>
        /// <param name="request"></param>
        public AcceptCoverSetCommand(AcceptCoverSetRequest request)
        {
            this.Id_Contrato = request.ParametroCont;
            this.ID_UsuarioEnvio = request.ParametroUsr;
            this.ID_Autorizador = request.ParametroAut;
            this.NombreAutorizador = request.NombreAutorizador;
            this.TipoAutorizador = request.TipoAutorizador;
            this.ExisteAutorizadores_Aut = request.ExisteAutorizadores_Aut;
            this.EsExtra = request.ParametroExtra;
            this.Vuelta = request.ParametroVuelta;
        }
        public long Id_Contrato { get; set; }
        /// <summary>
        /// ID_UsuarioEnvio
        /// </summary>
        public int ID_UsuarioEnvio { get; set; }
        public int ID_Autorizador { get; set; }
        public string NombreAutorizador { get; set; }
        public int TipoAutorizador { get; set; }
        public bool ExisteAutorizadores_Aut { get; set; }
        public int EsExtra { get; set; }
        public int Vuelta { get; set; }

    }
}
