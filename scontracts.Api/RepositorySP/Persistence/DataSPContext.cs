using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository.Core.Domain;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using scontracts.Api;

namespace RepositorySP.Persistence
{
    /// <summary>
    /// DataSPContext
    /// </summary>
    public class DataSPContext
    {
        /// <summary>
        /// _context
        /// </summary>
        private SqlConnection _context { get; set; }
        /// <summary>
        /// _transaction
        /// </summary>
        private SqlTransaction _transaction { get; set; }
        /// <summary>
        /// DataSPContext
        /// </summary>
        public DataSPContext()
        {
            try
            {
                var cnx = Startup.StaticConfig.GetConnectionString("ConsisDatabase");
                _context = new SqlConnection(cnx);
                _context.Open();
                _transaction = _context.BeginTransaction();
            }
            catch (Exception ex)
            {
                string sss = ex.Message;
                
            }
        }
        /// <summary>
        /// Command
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        public SqlCommand Command(string command)
        {
            SqlCommand cmd = new SqlCommand(command, _context, _transaction);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandTimeout = 9000;
            return cmd;
        }
        /// <summary>
        /// Dispose
        /// </summary>
        /// <returns></returns>
        public async Task Dispose()
        {
            if (_transaction != null)
            {
              await _transaction.DisposeAsync();
            }

            if (_context != null)
            {
                await _context.CloseAsync();
                await _context.DisposeAsync();
            }
        }
        /// <summary>
        /// Commit
        /// </summary>
        /// <returns></returns>
        public async Task Commit()
        {
           await _transaction.CommitAsync();
        }
    }
}

