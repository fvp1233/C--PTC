using Microsoft.VisualBasic.ApplicationServices;
using PTC2024.Controller.Helper;
using PTC2024.Model.DTO.PasswordRecoverDTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.ComponentModel.Design.ObjectSelectorEditor;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace PTC2024.Model.DAO.PasswordRecoverDAO
{
    internal class DAOAdminMethod : DTOAdminMethod
    {
        //Creamos el command
        readonly SqlCommand command = new SqlCommand();

        //Método para la validación de credenciales del administrador
        public bool ValidateAdminCredentials()
        {
            try
            {
                //conexión con la base
                command.Connection = getConnection();
                //creamos el query
                string query = "SELECT * FROM viewLogIn WHERE username = @username COLLATE SQL_Latin1_General_CP1_CS_AS AND password = @password COLLATE SQL_Latin1_General_CP1_CS_AS AND userStatus = @status AND IdBusinessP = 1 OR IdBusinessP = 3 AND username = @username AND password = @password";
                //Creamos el comando SQL con la conexión y el query
                SqlCommand cmd = new SqlCommand(query, command.Connection);
                //Damos valor a los parámetros del query
                cmd.Parameters.AddWithValue("username", AdminUsername);
                cmd.Parameters.AddWithValue("password", AdminPassword);
                cmd.Parameters.AddWithValue("status", 1);
                //Creamos el data reader
                SqlDataReader rd = cmd.ExecuteReader();
                while (rd.Read())
                {
                    string user = rd.GetString(0);
                    string role = rd.GetString(4);
                }
                return rd.HasRows;
            }
            catch (SqlException ex)
            {
                MessageBox.Show("EC-129: No se pudo obtener la información del logIn", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            finally
            {
                command.Connection.Close();
            }
        }

        //Método para verificar que el usuario existe en el sistema
        public bool CheckUser()
        {
            try
            {
                //Conexion con la base
                command.Connection = getConnection();
                //query de la consulta
                string query = "SELECT * FROM tbUserData WHERE username = @username COLLATE SQL_Latin1_General_CP1_CS_AS AND username = @username";
                //Creamos el comando SQL con la conexión y la base.
                SqlCommand cmd = new SqlCommand(query, command.Connection);
                //Damos valor a los parámetros
                cmd.Parameters.AddWithValue("username", EmployeeUsername);
                //Ejecutamos el comando
                cmd.ExecuteNonQuery();
                //Creamos un dataReader
                SqlDataReader rd = cmd.ExecuteReader();
                while (rd.Read())
                {
                    string username = rd.GetString(0);
                }
                return rd.HasRows;
            }
            catch (SqlException ex)
            {
                MessageBox.Show("EC-130: No se pudo obtener la información del usuario", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            finally
            {
                command.Connection.Close();
            }
        }

        //Método para verificar que el usuario ingresado se trata de un tipo empleado y no de un tipo administrador
        public bool CheckEmployeeUser()
        {
            try
            {
                //Conexion con la base
                command.Connection = getConnection();
                //query de la consulta
                string query = "SELECT * FROM tbUserData WHERE username = @username COLLATE SQL_Latin1_General_CP1_CS_AS AND IdBusinessP = 2 AND username = @username";
                //Creamos el comando SQL con la conexión y la base.
                SqlCommand cmd = new SqlCommand(query, command.Connection);
                //Damos valor a los parámetros
                cmd.Parameters.AddWithValue("username", EmployeeUsername);
                //Ejecutamos el comando
                cmd.ExecuteNonQuery();
                //Creamos un dataReader
                SqlDataReader rd = cmd.ExecuteReader();
                while (rd.Read())
                {
                    string username = rd.GetString(0);
                }
                return rd.HasRows;
            }
            catch (SqlException ex)
            {
                MessageBox.Show("EC-130: No se pudo obtener la información del usuario", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            finally
            {
                command.Connection.Close();
            }
        }

        //Método para la actualización de contraseña personalizada.
        public int UpdatePersonalizedPass()
        {
            try
            {
                //Conexion
                command.Connection = getConnection();
                //query de la consulta
                string query = "UPDATE tbUserData SET " +
                               "password = @password, " +
                               "temporalpassword = @temporalP " +
                               "WHERE username = @username ";
                //Comando SQL con el query y la conexión
                SqlCommand cmd = new SqlCommand(query, command.Connection);
                //damos valor a los parámetros de la consulta
                cmd.Parameters.AddWithValue("password", EmployeePassword);
                cmd.Parameters.AddWithValue("username", EmployeeUsername);
                cmd.Parameters.AddWithValue("temporalP", TemporalPass);
                //ejecutamos el comando y devolvemos la respuesta
                int answer = cmd.ExecuteNonQuery();
                return answer;
            }
            catch (SqlException ex)
            {
                MessageBox.Show("EC-008: No se pudieron actualizar los datos del usuario", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;               
            }
            finally
            {
                command.Connection.Close();
            }
        }

        public string RecoverPassword()
        {
            command.Connection = getConnection();
            string query = "SELECT * FROM viewPasswordRecover WHERE username = @username";
            SqlCommand cmd = new SqlCommand(query, command.Connection);
            cmd.Parameters.AddWithValue("@username", EmployeeUsername);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                int id = reader.GetInt32(0);
                string email = reader.GetString(1);
                string user = reader.GetString(2);
                string password = reader.GetString(3);

                //Creamos un random que nos va a generar la contraseña aleatoria
                Random random = new Random();

                //Ahora especificamos los carácteres que podrá tomar el random para generar la contraseña aleatoria
                const string chars = "ABCDEFGHJKLMNOPQRSTUVWXYZabcdefghijkmnpqrstuvwxyz0123456789";
                //Esta variable define la longitud del string anterior, para que el arreglo que se creará pueda agarrar de los 61 carácteres que se encuentran ahí.
                const int cLength = 61;

                //Creamos un arreglo de chars de una longitud de 6 dígitos
                var array = new char[6];

                //ahora creamos un for que se encargará de escoger aleatoriamente 6 carácteres y los guardará en nuestro arreglo
                for (int i = 0; i < 6; i++)
                {
                    array[i] = chars[random.Next(chars.Length)];
                }

                //Ahora le damos valor a nuestra variable string con lo que hay en el arreglo.
                string newPass = new string(array);
                EmployeePassword = newPass;
                if (UpdatePassword(user))
                {
                    Email objEmail = new Email();
                    objEmail.Send(email, "h2c.soporte.usuarios@gmail.com", "H2C: Recuperación de contraseña", "Hola " + user + ",\n\nSe realizó una recuperación de contraseña de tu usuario por medio de la intervención de administrador y esta fue restablecida, por lo que se te ha creado una contraseña temporal. \n\n" + "Tu contraseña temporal es: " + newPass + "\n\nTendrás que cambiar esta contraseña inmediatamente inicies sesión de nuevo en el sistema." + "\n\nSi tú no has solicitado esta recuperación de contraseña, ponte en contacto con el administrador.");
                    command.Connection.Close();
                    return "Se envió un correo electrónico de aviso al empleado.";
                }
            }
            command.Connection.Close();
            return "";
        }

        //actualizar contraseña
        public bool UpdatePassword(string user)
        {
            command.Connection = getConnection();
            string query = ("UPDATE tbUserData SET password = @password, temporalpassword = @temporalP WHERE username = @username");

            SqlCommand cmd = new SqlCommand(@query, command.Connection);

            CommonClasses encrypt = new CommonClasses();

            cmd.Parameters.AddWithValue("@username", EmployeeUsername);
            cmd.Parameters.AddWithValue("@password", encrypt.ComputeSha256Hash(EmployeePassword));
            cmd.Parameters.AddWithValue("@temporalP", TemporalPass);

            if (cmd.ExecuteNonQuery() > 0)
            {
                command.Connection.Close();
                return true;
            }
            else
            {
                command.Connection.Close();
                return false;
            }
        }
    }
}
