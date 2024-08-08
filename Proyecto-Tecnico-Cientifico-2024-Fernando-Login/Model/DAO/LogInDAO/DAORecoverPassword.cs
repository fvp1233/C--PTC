using PTC2024.Model.DTO.LogInDTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PTC2024.Controller.Helper;
using Microsoft.VisualBasic.ApplicationServices;

namespace PTC2024.Model.DAO.LogInDAO
{
    internal class DAORecoverPassword : DTORecoverPassword
    {
        readonly SqlCommand Command = new SqlCommand();
        public string recoverPassword(string recover)
        {
            Command.Connection = getConnection();
            string query = "SELECT * FROM viewPasswordRecover where(username = @username OR email = @email)";
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

                const string chars = "";
                const int cLength = 61;

                var buffer = new char[6];

                for (var i = 0; i < 6; ++i)
                {
                    buffer[i] = chars[random.Next(cLength)];
                }
                string newPass = new string(buffer);
                Password = newPass;
                if (UpdatePassword(User))
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
    }
}
