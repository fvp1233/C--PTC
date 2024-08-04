using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PTC2024.Model.DTO;
using PTC2024.Model.DTO.BillsDTO;

namespace PTC2024.Model.DAO.BillsDAO
{
    internal class DAOBills : DTOBills
    {
        readonly SqlCommand Command = new SqlCommand();

        public DataSet Bills()
        {
            try
            {
                Command.Connection = getConnection();
                string query = "SELECT * FROM viewBills";
                SqlCommand comd = new SqlCommand(query, Command.Connection);
                //comd.ExecuteNonQuery();
                SqlDataAdapter adap = new SqlDataAdapter(comd);
                DataSet ds = new DataSet();
                adap.Fill(ds, "viewBills");
                return ds;

            }
            catch (Exception)
            {
                return null;
                throw;
            }
            finally
            {
                getConnection().Close();
            }
        }
    }
}