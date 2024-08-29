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
                MessageBox.Show(ex.Message);
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
                MessageBox.Show(ex.Message);
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
                MessageBox.Show(ex.Message);
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
