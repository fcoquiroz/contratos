using scontracts.Shared.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace scontracts.Shared.Utilities
{
    public class ContractUtils
    {
        /// <summary>
        /// <para>Administrador = 1</para>
        /// <para>Gerente = 2</para>
        /// <para>Abogado = 3</para>
        /// <para>Solicitante = 4</para>
        /// <para>Reportes = 5</para>
        /// <para>Observador = 7</para>
        /// <para>Adm_Abg = 8</para>
        /// <para>Abogado_Altas = 9</para>
        /// </summary>
        public static Rol ObtenerTipoRol(int id)
        {
            switch (id)
            {
                case 1:
                    return Rol.Administrador;
                case 2:
                    return Rol.Gerente;
                case 3:
                    return Rol.Abogado;
                case 4:
                    return Rol.Solicitante;
                case 5:
                    return Rol.Reportes;
                case 7:
                    return Rol.Observador;
                case 8:
                    return Rol.Adm_Abg;
                case 9:
                    return Rol.Abogado_Altas;
                default:
                    return Rol.Solicitante; 
            }
        }
        /// <summary>
        /// Encode to Bas64
        /// </summary>
        /// <param name="cadena"></param>
        /// <returns></returns>
        public static string Encode(string cadena)
        {
            return Convert.ToBase64String(Encoding.UTF8.GetBytes(cadena));

        }
        /// <summary>
        /// Decode to Bas64
        /// </summary>
        /// <param name="cadena"></param>
        /// <returns></returns>
        public static string Decode(string cadena)
        {
            byte[] data = System.Convert.FromBase64String(cadena);
            return System.Text.ASCIIEncoding.ASCII.GetString(data);

        }




    }
}
