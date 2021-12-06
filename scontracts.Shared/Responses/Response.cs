using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace scontracts.Shared.Responses
{

    /// <summary>
    /// Basic ResponseT Class
    /// </summary>
    /// <typeparam name="T"> List class</typeparam>
    public class ResponseT<T>
    {
        /// <summary>
        /// Code
        /// </summary>
        public int Code { get; set; }

        /// <summary>
        /// Message
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// Data
        /// </summary>
        public T Data { get; set; }
        /// <summary>
        /// update
        /// </summary>
        /// <param name="code"></param>
        /// <param name="message"></param>
        public void update(int code, string message)
        {
            this.Code = code;
            this.Message = message;
        }
        /// <summary>
        /// update
        /// </summary>
        /// <param name="code"></param>
        /// <param name="message"></param>
        /// <param name="data"></param>
        public void update(int code, string message, T data)
        {
            this.Code = code;
            this.Message = message;
            this.Data = data;
        }


    }


    /// <summary>
    /// Basic ResponseList Class
    /// </summary>
    /// <typeparam name="T"> List class</typeparam>
    public class ResponseList<T>
    {
        /// <summary>
        /// Code
        /// </summary>
        public int Code { get; set; }

        /// <summary>
        /// Message
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// Data
        /// </summary>
        public List<T> Data { get; set; }
        /// <summary>
        /// update
        /// </summary>
        /// <param name="code"></param>
        /// <param name="message"></param>
        public void update(int code, string message)
        {
            this.Code = code;
            this.Message = message;
        }
        /// <summary>
        /// update
        /// </summary>
        /// <param name="code"></param>
        /// <param name="message"></param>
        /// <param name="data"></param>
        public void update(int code, string message, List<T> data)
        {
            this.Code = code;
            this.Message = message;
            this.Data = data;
        }


    }




}
