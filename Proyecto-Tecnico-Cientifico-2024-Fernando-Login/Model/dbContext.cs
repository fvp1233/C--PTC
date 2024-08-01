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
        public static SqlConnection getConnection()
        {
			try
			{

                string server = "PC\\SQLEXPRESS";
                string database = "DBPTC_H2C24";

                SqlConnection conexion = new SqlConnection($"Server = {server}; DataBase = {database}; Integrated Security = true");
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
