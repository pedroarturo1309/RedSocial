using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace RedSocial.Code
{
    public static class UtilityMethods
    {
        #region BLOQUE DE METODOS PARA ENCRIPTAR TEXTO
        /// <summary>
        /// Aplicar el algoritmo SHA1 al texto especificado
        /// </summary>
        /// <param name="texto">Texto a codificar</param>
        /// <returns>Texto codificado</returns>
        public static string SetSHA1(string texto)
        {
            SHA1 sha1 = SHA1.Create();
            ASCIIEncoding encoding = new ASCIIEncoding();
            byte[] stream = null;
            StringBuilder sb = new StringBuilder();
            stream = sha1.ComputeHash(encoding.GetBytes(texto));
            for (int i = 0; i < stream.Length; i++) sb.AppendFormat("{0:x2}", stream[i]);
            return sb.ToString();
        }

        /// <summary>
        /// Metodo de Encryptacion MD5
        /// </summary>
        /// <param name="input">Valor a encryptar</param>
        /// <returns>string encryptado</returns>
        public static string GetMD5(string input)
        {
            // Convert the input string to a byte array and compute the hash.
            MD5 md5Hashs = MD5.Create();

            byte[] data = md5Hashs.ComputeHash(Encoding.UTF8.GetBytes(input));

            // Create a new Stringbuilder to collect the bytes
            // and create a string.
            StringBuilder sBuilder = new StringBuilder();

            // Loop through each byte of the hashed data 
            // and format each one as a hexadecimal string.
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            // Return the hexadecimal string.
            return sBuilder.ToString();
        }

        /// <summary>
        /// Metodo para encriptar el ID que pasamos por el navegador
        /// </summary>
        /// <param name="ToEncrypt"></param>
        /// <returns>Valor encriptado</returns>
        public static string encryptURL(string ToEncrypt)
        {
            return Convert.ToBase64String(Encoding.ASCII.GetBytes(ToEncrypt));
        }


        /// <summary>
        /// Metodo para Desencriptar la URL
        /// </summary>
        /// <param name="cypherString">Cadena cifrada que se desea desencriptar</param>
        /// <returns>Texto desencriptado</returns>
        public static string decryptURL(string cypherString)
        {
            return Encoding.ASCII.GetString(Convert.FromBase64String(cypherString));
        }
        #endregion
    }
}