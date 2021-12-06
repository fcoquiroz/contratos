using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;

namespace scontracts.Api.Helpers
{
    /// <summary>
    /// ErrorLogFile
    /// </summary>
    public class ErrorLogFile
    {



        #region Configure logger
        /// <summary>
        /// ILoggerFactory
        /// </summary>
        private static ILoggerFactory _Factory = null;


        /// <summary>
        /// ConfigureLogger
        /// </summary>
        /// <param name="loggerFactory"></param>
        public static void ConfigureLogger(ILoggerFactory loggerFactory)
        {

            loggerFactory.AddFile(Startup.StaticConfig.GetSection("Logging"));
        }

        /// <summary>
        /// LoggerFactory
        /// </summary>
        public static ILoggerFactory LoggerFactory
        {
            get
            {
                if (_Factory == null)
                {
                    _Factory = new LoggerFactory();
                    ConfigureLogger(_Factory);
                }
                return _Factory;
            }
            set { _Factory = value; }
        }
        /// <summary>
        /// CreateLogger
        /// </summary>
        /// <returns></returns>
        public static ILogger CreateLogger() => LoggerFactory.CreateLogger(typeof(ErrorLogFile));
        #endregion
        /// <summary>
        /// LogCritical
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        internal static string LogCritical(string message)
        {
            CreateLogger().LogCritical(message);
            return message;
        }



    }
}
