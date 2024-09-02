using PTC2024.Model.DTO.ProfileDTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using System.Windows.Forms;

namespace PTC2024.Model.DAO.ProfileDAO
{
    internal class DAOProfileConfiguration : DTOProfile
    {
        readonly SqlCommand command = new SqlCommand();

        public int SaveInfo()
        {
            try
            {
                command.Connection = getConnection();
                string query = "UPDATE tbUserData SET profilePicture = @param1 WHERE username = @param2";
                SqlCommand cmd = new SqlCommand(query, command.Connection);
                cmd.Parameters.AddWithValue("param1", ProfilePicture);
                cmd.Parameters.AddWithValue("param2", Username);
                int returnedValue = cmd.ExecuteNonQuery();
                return returnedValue;
            }
            catch (SqlException ex)
            {
                MessageBox.Show($"Excepcion SQL: {ex.Message}", "Error al procesar información", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
            finally
            {
                command.Connection.Close();
            }
        }
    }
}
