using PTC2024.Model.DTO.ProfileDTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PTC2024.Model.DAO.ProfileDAO
{
    internal class DAOChangeUserPass : DTOChangeUserPass
    {
        readonly SqlCommand command = new SqlCommand();

        public bool CheckPass()
        {
            try
            {
                command.Connection = getConnection();
                string query = "SELECT * FROM tbUserData WHERE username = @username COLLATE SQL_Latin1_General_CP1_CS_AS AND password = @password COLLATE SQL_Latin1_General_CP1_CS_AS AND username = @username AND password = @password";
                SqlCommand cmd = new SqlCommand(query, command.Connection);
                cmd.Parameters.AddWithValue("username", Username);
                cmd.Parameters.AddWithValue("password", ActualPass);
                SqlDataReader rd = cmd.ExecuteReader();
                while (rd.Read())
                {
                    string user = rd.GetString(0);
                }
                return rd.HasRows;
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
            finally
            {
                command.Connection.Close();
            }
        }

        public int UpdatePass()
        {
            try
            {
                command.Connection = getConnection();
                string query = "UPDATE tbUserData SET " +
                               "password = @newPass " +
                               "WHERE username = @user";
                SqlCommand cmd = new SqlCommand(query, command.Connection);
                cmd.Parameters.AddWithValue("newPass", NewPass);
                cmd.Parameters.AddWithValue("user", Username);
                int answer = cmd.ExecuteNonQuery();
                return answer;
            }
            catch (SqlException ex)
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
