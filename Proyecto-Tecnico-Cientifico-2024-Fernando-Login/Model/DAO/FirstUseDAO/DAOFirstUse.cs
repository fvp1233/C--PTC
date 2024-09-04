
using PTC2024.Model.DTO.FirstUseDTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PTC2024.Model.DAO.FirstUseDAO
{
    internal class DAOFirstUse:DTOFistUse
    {
        readonly SqlCommand command = new SqlCommand();
        public bool AddBusiness()
        {
            try
            {
                command.Connection = getConnection();
                string query = "INSERT INTO tbBusinessInfo VALUES(@param1, @param2, @param3, @param4, @param5, @param6, @param7)";
                SqlCommand cmd = new SqlCommand(query,command.Connection);
                cmd.Parameters.AddWithValue("param1", NameBusiness);
                cmd.Parameters.AddWithValue("param2", AddressBusiness);
                cmd.Parameters.AddWithValue("param3", EmailBusiness);
                cmd.Parameters.AddWithValue("param4", DateBusiness);
                cmd.Parameters.AddWithValue("param5", PhoneBusiness);
                cmd.Parameters.AddWithValue("param6", PbxBusiness);
                cmd.Parameters.AddWithValue("param7", ImageBusiness);
                int returnedValue = cmd.ExecuteNonQuery();
                return returnedValue > 0;

            }
            catch (SqlException ex)
            {
                MessageBox.Show($"EC-002: No se pudieron insertar los datos", "Error al procesar información", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            finally
            {
                command.Connection.Close();
            }
        }
        public int VerifyRegister()
        {
            try
            {
               command.Connection = getConnection();
                string query = "SELECT COUNT(*) FROM tbBusinessInfo";
                SqlCommand cmd = new SqlCommand(query, command.Connection);
                int total = (int)cmd.ExecuteScalar();
                return total;

            }
            catch (SqlException sqlex)
            {
                MessageBox.Show($"EC-001: No se pudo verificar la existencia de una empres registrada en el sistema", "Error al verificar información", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return -1;
            }
            finally
            {
                command.Connection.Close();
            }
        }
    }
}
