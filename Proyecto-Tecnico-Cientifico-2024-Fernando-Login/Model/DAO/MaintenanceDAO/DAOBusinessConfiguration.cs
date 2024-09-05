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
                string query = "UPDATE tbBusinessInfo SET nameBusiness = @param1, addressBussines = @param2, emailBusiness = @param3, phoneBusiness = @param4, pbxBusiness = @param5, imageBusiness = @param6 WHERE idBusiness = @param7";
                SqlCommand cmd = new SqlCommand(query, Command.Connection);
                cmd.Parameters.AddWithValue("nameBusiness", NameBusiness);
                cmd.Parameters.AddWithValue("addressBussines", AddressBusiness);
                cmd.Parameters.AddWithValue("emailBusiness", EmailBusiness);
                cmd.Parameters.AddWithValue("phoneBusiness", PhoneBusiness);
                cmd.Parameters.AddWithValue("pbxBusiness", PbxBusiness);
                cmd.Parameters.AddWithValue("imageBusiness", ImageBusiness);
                cmd.Parameters.AddWithValue("idBusiness", IdBusiness);
                int answer = cmd.ExecuteNonQuery();
                return answer;
            }
            catch (Exception)
            {
                MessageBox.Show("EC-137: No se pudo actualizar la información del negocio", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }
            finally
            {
                getConnection().Close();
            }
        }
    }
}
