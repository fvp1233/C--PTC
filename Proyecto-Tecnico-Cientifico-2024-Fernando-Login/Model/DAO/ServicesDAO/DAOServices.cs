using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PTC2024.Model.DTO.ServicesDTO;

namespace PTC2024.Model.DAO.ServicesDAO
{
    internal class DAOServices : DTOServices
    {

        readonly SqlCommand command = new SqlCommand();

        public DataSet GetDataTable()
        {
            try
            {
                command.Connection = getConnection();
                string query = "SELECT * FROM viewServices";

                SqlCommand cmd = new SqlCommand(query, command.Connection);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);

                DataSet ds = new DataSet();

                adp.Fill(ds, "tbServices");
                return ds;

            }
            catch (Exception)
            {
                return null;
            }
            finally
            {
                command.Connection.Close();
            }
        }
    }
}
