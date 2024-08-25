using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using PTC2024.Model.DTO.ProfileDTO;
using System.Windows.Forms;

namespace PTC2024.Model.DAO.ProfileDAO
{
    internal class DAOProfile : DTOProfile
    {
        readonly SqlCommand comand = new SqlCommand();

        public DataSet GetEmployee()
        {
            try
            {
                comand.Connection = getConnection();
                string queryEmployee = "SELECT * FROM tbEmployee ";
                SqlCommand cmdEmployeeInfo = new SqlCommand(@queryEmployee, comand.Connection);
                cmdEmployeeInfo.ExecuteNonQuery();
                SqlDataAdapter adp = new SqlDataAdapter(cmdEmployeeInfo);
                DataSet ds = new DataSet();
                adp.Fill(ds, "tbEmployee");
                return ds;
            }
            catch (Exception)
            {
                return null;
            }
            finally
            {
                getConnection().Close();
            }
        }
        public int SaveInfo()
        {
            try
            {
                comand.Connection = getConnection();
                string query = "UPDATE tbUserData SET profilePicture = @param1 WHERE username = @param2";
                SqlCommand cmd = new SqlCommand(query, comand.Connection);
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
                comand.Connection.Close();
            }
        }
    }
}
