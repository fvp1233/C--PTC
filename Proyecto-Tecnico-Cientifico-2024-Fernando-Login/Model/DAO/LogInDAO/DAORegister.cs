using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PTC2024.Model.DTO;
using PTC2024.Model.DTO.LogInDTO;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Web.Hosting;

namespace PTC2024.Model.DAO.LogInDAO
{
    internal class DAORegister:DTORegister
    {
        readonly SqlCommand command = new SqlCommand();

        public DataSet ObtainNames()
        {
            try
            {
                command.Connection = getConnection();
                string query = "SELECT * FROM userData";
                SqlCommand cmd = new SqlCommand(query, command.Connection);
                cmd.ExecuteNonQuery();

                SqlDataAdapter adp = new SqlDataAdapter(cmd);

                DataSet ds = new DataSet();
                adp.Fill(ds, "tbName");

                return ds;
            }
            catch (SqlException ex)
            {

                MessageBox.Show($"{ex.Message}EC-005 ERROR BELLAKO: No se puedieron obtener los datos de los Nombres del usuario  ");
                return null;
            }
            finally
            {
                command.Connection.Close();
            }
        


        }
    }
}
