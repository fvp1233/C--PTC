using Microsoft.VisualBasic.ApplicationServices;
using PTC2024.Model.DTO.HelperDTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PTC2024.Model
{
    internal class dbContext
    {
        private string server;
        private string database;
        private string user;
        private string password;

        public string Server { get => server; set => server = value; }
        public string Database { get => database; set => database = value; }
        public string User { get => user; set => user = value; }
        public string Password { get => password; set => password = value; }

        public static SqlConnection getConnection()
        {
            try
            {
                SqlConnection connection;
                if (string.IsNullOrEmpty(DTOXMLConnection.User) && string.IsNullOrEmpty(DTOXMLConnection.Password))
                {
                    connection = new SqlConnection($"Server = {DTOXMLConnection.Server}; DataBase = {DTOXMLConnection.Database}; IntegratednSecurity = true");
                }
                else
                {
                    connection = new SqlConnection($"Server = {DTOXMLConnection.Server}; DataBase = {DTOXMLConnection.Database}; User Id = {DTOXMLConnection.User}; Password = {DTOXMLConnection.Password}");
                }
                //string server = DTOXMLConnection.Server;
                //string database = DTOXMLConnection.Database;
                //string userId = DTOXMLConnection.User;
                //string Password = DTOXMLConnection.Password;
                //SqlConnection conexion = new SqlConnection($"Server = {server}; DataBase = {database}; User Id = {userId}; Password = {Password}");
                connection.Open();
                return connection;
            }

            catch (SqlException ex)
            {
                MessageBox.Show("Código de error: EC-001 \nNo fue posible conectarse a la base de datos, favor verifique las credenciales o que tenga acceso al sistema.", "Error crítico", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        //Prueba de conexión
        public static SqlConnection VerifyConnection(string server, string database, string user, string password)
        {
            try
            {
                SqlConnection connection;
                if (string.IsNullOrEmpty(user) && string.IsNullOrEmpty(password))
                {
                    connection = new SqlConnection($"Server = {server}; DataBase = {database}; Integrated Security = true");
                }
                else
                {
                    connection = new SqlConnection($"Server = {server}; DataBase = {database}; User Id = {user}; Password = {password}");

                }
                //SqlConnection conexion = new SqlConnection($"Server = {server}; DataBase = {database}; User Id = {user}; Password = {password}");
                connection.Open();
                return connection;
            }
            catch (SqlException ex)
            {
                MessageBox.Show($"{ex.Message} Código de error: EC-001 \nNo fue posible conectarse a la base de datos, verifique las credenciales, consulte el manual de usuario.", "Error crítico", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        #region GetConnection para conexión a una base de manera local
        //public static SqlConnection getConnection()
        //{
        //    try
        //    {

        //        string server = "DESKTOP-L1S3JL8";
        //        string database = "DBPTC_H2C24";

        //        SqlConnection conexion = new SqlConnection($"Server = {server}; DataBase = {database}; Integrated Security = true");
        //        conexion.Open();
        //        return conexion;
        //    }
        //    catch (SqlException ex)
        //    {
        //        MessageBox.Show("Código de error: EC-001 \nNo fue posible conectarse a la base de datos, favor verifique las credenciales o que tenga acceso al sistema.", "Error crítico", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        return null;
        //    }
        //}
        #endregion
    }
}
