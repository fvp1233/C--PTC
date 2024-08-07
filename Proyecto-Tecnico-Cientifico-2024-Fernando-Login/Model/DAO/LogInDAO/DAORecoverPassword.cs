using PTC2024.Model.DTO.LogInDTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PTC2024.Controller.Helper;
using Microsoft.VisualBasic.ApplicationServices;
using System.Windows.Forms;

namespace PTC2024.Model.DAO.LogInDAO
{
    internal class DAORecoverPassword : DTORecoverPassword
    {
        readonly SqlCommand Command = new SqlCommand();
        public string recoverPassword()
        {
            Command.Connection = getConnection();
            string query = "SELECT * FROM viewPasswordRecover WHERE username = @username AND email = @email";
            SqlCommand cmd = new SqlCommand(query, Command.Connection);
            cmd.Parameters.AddWithValue("@username",User);
            cmd.Parameters.AddWithValue("@email", Email);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                int id = reader.GetInt32(0);
                string email = reader.GetString(1);
                string user = reader.GetString(2);
                string password = reader.GetString(3);

                Random random = new Random();

                const string chars = "ABCDEFGHJKLMNOPQRSTUVWXYZabcdefghijkmnpqrstuvwxyz0123456789";
                const int cLength = 61;

                var buffer = new char[6];

                for (var i = 0; i < 6; ++i)
                {
                    buffer[i] = chars[random.Next(cLength)];
                }
                string newPass = new string(buffer);
                Password = newPass;
                if (UpdatePassword(user))
                {
                    var mailService = new Email();
                    mailService.Send(email, "h2c.soporte.usuarios@gmail.com", "H2C: Recuperación de contraseña", "Hola " + user + ",\n\nHas solicitado recuperar tu contraseña. \n"+ "Tu contraseña nueva es: " + newPass);
                    Command.Connection.Close();
                    return "Hola, " + user + "\nHas solicitado recuperar tu contraseña. \n" + "Por favor revisa tu coreo: " + email;
                }
            }
            Command.Connection.Close();
            return "";
        }
        public bool UpdatePassword(string user)
        {
            Command.Connection = getConnection();
            string query = ("UPDATE tbUserData SET password = @password WHERE username = @username");

            SqlCommand cmd = new SqlCommand(@query, Command.Connection);

            CommonClasses encrypt = new CommonClasses();

            cmd.Parameters.AddWithValue("@username", User);
            cmd.Parameters.AddWithValue("@password", encrypt.ComputeSha256Hash(Password));
            if(cmd.ExecuteNonQuery() >0)
            {
                Command.Connection.Close();
                return true;
            }
            else
            {
                Command.Connection.Close();
                return false;
            }
        }
        public bool ValidateCredentials()
        {
            try
            {
                Command.Connection = getConnection();
                string query = "SELECT * FROM viewPasswordRecover WHERE username = @username AND email = @email";
                SqlCommand cmd = new SqlCommand(query, Command.Connection);
                cmd.Parameters.AddWithValue("@username", User);
                cmd.Parameters.AddWithValue("@email", Email);
                SqlDataReader rd = cmd.ExecuteReader();
                while(rd.Read())
                {
                    IdEmployee = rd.GetInt32(0);
                    Email = rd.GetString(1); 
                    User = rd.GetString(2);
                    Password = rd.GetString(3);
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
