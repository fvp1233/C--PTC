using PTC2024.Model.DTO.PayrollDTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PTC2024.Model.DAO.PayrollsDAO
{
    internal class DAOPermission : DTOPermission
    {
        readonly SqlCommand Command = new SqlCommand();
        public DataSet GetPermissions()
        {
            try
            {
                Command.Connection = getConnection();
                string query = "SELECT * FROM viewPermissions";
                SqlCommand cmd = new SqlCommand(query, Command.Connection);
                cmd.ExecuteNonQuery();
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                adp.Fill(ds, "viewPermissions");
                return ds;
            }
            catch (SqlException ex)
            {
                MessageBox.Show("EC-0100: No se puedieron obtener los datos de la tabla tbStatusPermission");
                return null;
            }
            finally
            {
                Command.Connection.Close();
            }
        }
    }
}
