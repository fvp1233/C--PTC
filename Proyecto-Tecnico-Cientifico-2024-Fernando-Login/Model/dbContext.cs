using Microsoft.VisualBasic.ApplicationServices;
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
                string server = "SQL8005.site4now.net";
                string database = "db_aaa7ca_ricaldone";
                string userId = "db_aaa7ca_ricaldone_admin";
                string Password = "Master2024";
                SqlConnection conexion = new SqlConnection($"Server = {server}; DataBase = {database}; User Id = {userId}; Password = {Password}");
                conexion.Open();
                return conexion;
            }

			catch (SqlException ex)
			{
                MessageBox.Show("Código de error: EC-001 \nNo fue posible conectarse a la base de datos, favor verifique las credenciales o que tenga acceso al sistema.", "Error crítico", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
			}
        }
    }
}
