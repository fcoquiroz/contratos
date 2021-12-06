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
    /// ManagementCoverCommand
    /// </summary>
    public class ManagementCoverCommand : ManagementCoverRequest, IRequest<ResponseT<ManagementCoverResponse>>
    {
        /// <summary>
        /// ManagementCoverCommand
        /// </summary>
        /// <param name="request"></param>
        public ManagementCoverCommand(ManagementCoverRequest request)
        {
            
            this.ID_Contrato = request.ID_Contrato;
            this.ID_Usuario_Envio = request.ID_Usuario_Envio;
            this.HfArrayNombre = request.HfArrayNombre;
            this.Inversion = request.Inversion;
            this.Capacidad = request.Capacidad;
            this.Pena = request.Pena;
            this.Accion = request.Accion;
            this.Extra = request.Extra;
            this.ID_Usuario = request.ID_Usuario;

            this.Nombre = request.Nombre;
            this.Correo = request.Correo;
            this.ID_TipoAutorizador = request.ID_TipoAutorizador;
            this.ID_TipoCaratula = request.ID_TipoCaratula;
            this.ID_Producto = request.ID_Producto;
            this.ID_Pais = request.ID_Pais;
            this.idAutorizador = request.idAutorizador;
            this.Comentarios = request.Comentarios;
        }
       

    }
}
