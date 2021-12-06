using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository.Core.Domain;
using Repository.Core.Repositories;
using Microsoft.EntityFrameworkCore;

using Newtonsoft.Json;
namespace Repository.Persistence.Repositories
{
    /// <summary>
    /// TB_Contratos_AppointmentRepository
    /// </summary>
    public class TB_Contratos_AppointmentRepository : Repository<TB_Contratos_Appointment>, ITB_Contratos_AppointmentRepository
    {
        /// <summary>
        /// TB_Contratos_AppointmentRepository
        /// </summary>
        /// <param name="_conTB_Contratos_AppointmentRepositorytext"></param>
        public TB_Contratos_AppointmentRepository(DataContext _context) : base(_context) { }
        /// <summary>
        /// consisContext
        /// </summary>
        public DataContext consisContext { get { return Context as DataContext; } }
    }
}
