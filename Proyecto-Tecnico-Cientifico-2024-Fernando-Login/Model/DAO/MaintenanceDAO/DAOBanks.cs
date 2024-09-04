using PTC2024.Model.DTO.MaintenanceDTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Configuration;
using System.Windows.Forms;

namespace PTC2024.Model.DAO.MaintenanceDAO
{
    internal class DAOBanks : DTOBanks
    {
        readonly SqlCommand command = new SqlCommand();

        public DataSet GetBanks()
        {
            try
            {
                command.Connection = getConnection();
                string query = "SELECT * FROM viewBanks";
                SqlCommand cmd = new SqlCommand(query, command.Connection);
                cmd.ExecuteNonQuery();
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                adp.Fill(ds, "viewBanks");
                return ds;
            }
            catch (SqlException ex)
            {
                MessageBox.Show("EC-124: No se pudo obtener los bancos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;               
            }
            finally
            {
                command.Connection.Close();
            }
        }

        public int AddBank()
        {
            try
            {
                command.Connection = getConnection();
                string query = "INSERT INTO tbBanks (BankName) VALUES (@param1)";
                SqlCommand cmd = new SqlCommand(query, command.Connection);
                cmd.Parameters.AddWithValue("param1", Bank);
                int answer = cmd.ExecuteNonQuery();
                return answer;
            }
            catch (SqlException ex)
            {
                MessageBox.Show("EC-125: No se pudo agregar el banco", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }
            finally
            {
                command.Connection.Close();
            }
        }

        public int DeleteBank()
        {
            try
            {
                command.Connection = getConnection();
                string queryDelete = "DELETE FROM tbBanks WHERE IdBank = @idBank";
                SqlCommand cmd = new SqlCommand(queryDelete, command.Connection);
                cmd.Parameters.AddWithValue("idBank", IdBank);
                int answer = cmd.ExecuteNonQuery();
                return answer;
            }
            catch (SqlException ex)
            {
                MessageBox.Show("EC-126: No se pudo eliminar el banco", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }
            finally
            {
                command.Connection.Close();
            }
        }
    }
}
