using Repository.Core.Domain;
using Repository.Core.Repositories;
using scontracts.Api.Mediator.Commands;
using scontracts.Shared.DTO;
using scontracts.Shared.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Repository.Core.Repositories
{
    public interface ITB_Detalle_CaratulaRepository : IRepository<TB_Detalle_Caratula>
    {
        /// <summary>
        /// ObtenerDetalleCaratula
        /// </summary>
        /// <param name="ID_Contrato"></param>
        /// <returns></returns>
        List<CoverDetalleDataGetDTO> ObtenerDetalleCaratula(int ID_Contrato);
        /// <summary>
        /// InsertXInversion
        /// </summary>
        /// <param name="Inversion"></param>
        /// <param name="id_contrato"></param>
        void InsertXInversion(string Inversion, int id_contrato);
        /// <summary>
        /// InsertXCapacidad
        /// </summary>
        /// <param name="Capacidad"></param>
        /// <param name="id_contrato"></param>
        void InsertXCapacidad(string Capacidad, int id_contrato);
        /// <summary>
        /// InsertXPena
        /// </summary>
        /// <param name="Pena"></param>
        /// <param name="id_contrato"></param>
        void InsertXPena(string Pena, int id_contrato);
        /// <summary>
        /// Moneda
        /// </summary>
        /// <param name="id_contrato"></param>
        void Moneda(int id_contrato);
        /// <summary>
        /// InsertClientesProductoPais
        /// </summary>
        /// <param name="id_contrato"></param>
        void InsertClientesProductoPais(int id_contrato);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="command"></param>
        void GuardarDetalleCaratula(ManagementCoverCommand command);
        /// <summary>
        /// GuardarExisteDetalleCaratula
        /// </summary>
        /// <param name="command"></param>
        void GuardarExisteDetalleCaratula(ManagementCoverCommand command);
        /// <summary>
        /// ObtenerDetalleCaratulaCampo
        /// </summary>
        /// <param name="id_campo"></param>
        /// <returns></returns>
        //List<CoverDetalleDataGetDTO> ObtenerDetalleCaratulaCampo(int id_campo);

    }
}
