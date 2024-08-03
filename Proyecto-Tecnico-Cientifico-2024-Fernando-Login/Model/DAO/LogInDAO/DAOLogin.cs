using PTC2024.Controller.Helper;
using PTC2024.Model.DTO.LogInDTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PTC2024.Model.DAO.LogInDAO
{
    internal class DAOLogin : DTOLogin
    {
        SqlCommand command = new SqlCommand();
        public bool ValidarLogin()
        {
            try
            {
                command.Connection = getConnection();
                string query = "SELECT * FROM viewLogIn WHERE username = @username AND password = @password  AND userStatus = @status";
                SqlCommand cmd = new SqlCommand(query, command.Connection);
                cmd.Parameters.AddWithValue("username", Username);
                cmd.Parameters.AddWithValue("password", Password);
                cmd.Parameters.AddWithValue("status", UserStatus);
                SqlDataReader rd = cmd.ExecuteReader();
                while (rd.Read())
                {
                    SessionVar.Username = rd.GetString(0);
                    SessionVar.Password = rd.GetString(1);
                    SessionVar.IdBussinesP = rd.GetInt32(3);
                    SessionVar.Access = rd.GetString(4);
                    SessionVar.FullName = rd.GetString(5);
                }
                return rd.HasRows;
            }
            catch (SqlException sqlex)
            {
                MessageBox.Show(sqlex.Message);
                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
            finally
            {
                getConnection().Close();
            }
        }
    }
}
