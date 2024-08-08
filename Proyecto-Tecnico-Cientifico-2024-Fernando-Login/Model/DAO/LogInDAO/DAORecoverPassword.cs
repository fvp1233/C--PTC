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
        public string RecoverPassword()
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

                string newPass = user + "CR321";
                Password = newPass;
                if (UpdatePassword(user))
                {
                    Email objEmail = new Email();
                    objEmail.Send(email, "h2c.soporte.usuarios@gmail.com", "H2C: Recuperación de contraseña", "Hola " + user + ",\n\nHas solicitado recuperar tu contraseña, por lo que la hemos restablecido. \n"+ "Tu nueva contraseña es: " + newPass + "\n\n Tendrás que cambiar esta contraseña inmediatamente inicies sesión de nuevo en el sistema.");
                    Command.Connection.Close();
                    return "Hola, " + user + "\nUsted solicitó una recuperación de contraseña. \n" + "Revise su correo para más información: " + email;
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
