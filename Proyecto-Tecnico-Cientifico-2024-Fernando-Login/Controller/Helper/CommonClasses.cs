using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace PTC2024.Controller.Helper
{
    internal class CommonClasses
    {
        /// <summary>
        /// Método para crear bordes redondos en el formulario
        /// </summary>
        /// <param name="nLeftRect"></param>
        /// <param name="nTopRect"></param>
        /// <param name="nRightRect"></param>
        /// <param name="nBottomRect"></param>
        /// <param name="nWidthEllipse"></param>
        /// <param name="nHeightEllipse"></param>
        /// <returns></returns>
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        public static extern IntPtr CreateRoundRectRgn
        (
            int nLeftRect,     // x-coordinate of upper-left corner
            int nTopRect,      // y-coordinate of upper-left corner
            int nRightRect,    // x-coordinate of lower-right corner
            int nBottomRect,   // y-coordinate of lower-right corner
            int nWidthEllipse, // width of ellipse
            int nHeightEllipse // height of ellipse
        );


        public string ComputeSha256Hash(string rawData)
        {
            // Crear una instancia de SHA256
            using (SHA256 sha256Hash = SHA256.Create())
            {
                // Computar el hash - devuelve un arreglo de bytes
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));

                // Convertir byte array a string
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }

        //Método para descifrar un texto 
        public string DecodeString(string encodedString)
        {
            try
            {
                byte[] decodedBytes = Convert.FromBase64String(encodedString);
                // Convertir los bytes a una cadena
                string decodedString = Encoding.UTF8.GetString(decodedBytes);
                return decodedString.ToString();
            }
            catch (Exception ex)
            {
                return $"Error al descifrar: {ex.Message}";
            }
        }

        public string EncodeString(string stringToEncode)
        {
            try
            {
                byte[] bytes = Encoding.UTF8.GetBytes(stringToEncode);
                //Codificación base 64 string
                string base64String = Convert.ToBase64String(bytes);
                return base64String;
            }
            catch (Exception)
            {
                return string.Empty;
            }
        }
    }
}
