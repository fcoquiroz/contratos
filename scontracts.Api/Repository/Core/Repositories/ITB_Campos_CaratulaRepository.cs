using Repository.Core.Domain;
using scontracts.Shared.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Repository.Core.Repositories
{
    public interface ITB_Campos_CaratulaRepository : IRepository<TB_Campos_Caratula>
    {
        /// <summary>
        /// ObtenerCamposCaratula
        /// </summary>
        /// <param name="id_contrato"></param>
        /// <returns></returns>
        List<CoverDataGetDTO> ObtenerCamposCaratula(long id_contrato);
        /// <summary>
        /// ObtenerCamposCaratulaNombreColumna
        /// </summary>
        /// <param name="id_contrato"></param>
        /// <param name="BanderaCaratula"></param>
        /// <returns></returns>
        List<CoverDataGetDTO> ObtenerCamposCaratulaNombreColumna(long id_contrato, int BanderaCaratula);
    }
}
