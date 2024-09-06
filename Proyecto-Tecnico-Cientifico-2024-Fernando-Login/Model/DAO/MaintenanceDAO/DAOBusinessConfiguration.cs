using PTC2024.Model.DTO.MaintenanceDTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;

namespace PTC2024.Model.DAO.MaintenanceDAO
{
    internal class DAOBusinessConfiguration : DTOBusinessConfiguration
    {
        readonly SqlCommand Command = new SqlCommand();
        public int UpdateBusinessInfo()
        {
            try
            {
                Command.Connection = getConnection();
                string query = "UPDATE tbBusinessInfo SET nameBusiness = @param1, addressBussines = @param2, emailBusiness = @param3, phoneBusiness = @param4, pbxBusiness = @param5 WHERE idBusiness = @param6";
                SqlCommand cmd = new SqlCommand(query, Command.Connection);
                cmd.Parameters.AddWithValue("param1", NameBusiness);
                cmd.Parameters.AddWithValue("param2", AddressBusiness);
                cmd.Parameters.AddWithValue("param3", EmailBusiness);
                cmd.Parameters.AddWithValue("param4", PhoneBusiness);
                cmd.Parameters.AddWithValue("param5", PbxBusiness);
                cmd.Parameters.AddWithValue("param6", IdBusiness);
                int answer = cmd.ExecuteNonQuery();
                return answer;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex}EC-137: No se pudo actualizar la información del negocio", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }
            finally
            {
                getConnection().Close();
            }
        }
        public int SavePfp()
        {
            try
            {
                Command.Connection = getConnection();
                string query = "UPDATE tbBusinessInfo SET imageBusiness = @param1 WHERE idBusiness = @param2";
                SqlCommand cmd = new SqlCommand(query, Command.Connection);
                cmd.Parameters.AddWithValue("param1", ImageBusiness);
                cmd.Parameters.AddWithValue("param2", IdBusiness);
                int returnedValue = cmd.ExecuteNonQuery();
                return returnedValue;
            }
            catch (SqlException ex)
            {
                MessageBox.Show("EC-008: No se pudieron actualizar los datos del usuario", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
            finally
            {
                Command.Connection.Close();
            }
        }
    }
}
