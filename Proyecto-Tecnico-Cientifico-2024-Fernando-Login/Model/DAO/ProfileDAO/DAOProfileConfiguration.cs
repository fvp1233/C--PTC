using PTC2024.Model.DTO.ProfileDTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using System.Windows.Forms;
using System.Xml.Linq;
using PTC2024.Controller.Helper;

namespace PTC2024.Model.DAO.ProfileDAO
{
    internal class DAOProfileConfiguration : DTOProfile
    {
        readonly SqlCommand command = new SqlCommand();

        public int SavePfp()
        {
            try
            {
                command.Connection = getConnection();
                string query = "UPDATE tbUserData SET profilePicture = @param1 WHERE username = @param2";
                SqlCommand cmd = new SqlCommand(query, command.Connection);
                cmd.Parameters.AddWithValue("param1", ProfilePicture);
                cmd.Parameters.AddWithValue("param2", Username);
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
                command.Connection.Close();
            }
        }

        public int UpdateInfo()
        {
            try
            {
                command.Connection = getConnection();
                string query = "UPDATE tbEmployee SET " +
                               "names = @param1, " +
                               "lastName = @param2, " +
                               "DUI = @param3, " +
                               "email = @param4, " +
                               "phone = @param5, " +
                               "address = @param6, " +
                               "bankAccount = @param7," +
                               "affiliationNumber = @param8 " +
                               "WHERE username = @user";
                SqlCommand cmd = new SqlCommand(query, command.Connection);
                cmd.Parameters.AddWithValue("param1", FirstName);
                cmd.Parameters.AddWithValue("param2", LastName);
                cmd.Parameters.AddWithValue("param3", Dui);
                cmd.Parameters.AddWithValue("param4", Email);
                cmd.Parameters.AddWithValue("param5", Phone);
                cmd.Parameters.AddWithValue("param6", Address);
                cmd.Parameters.AddWithValue("param7", BanckAccount);
                cmd.Parameters.AddWithValue("param8", SecurityNumber);
                cmd.Parameters.AddWithValue("user", Username);
                //ejecutamos el comando
                int answer = cmd.ExecuteNonQuery();
                return answer;
            }
            catch (SqlException ex)
            {
                MessageBox.Show("EC-033: No se pudieron actualizar los datos del empleado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
                
            }
            finally
            {
                command.Connection.Close();
            }
        }

        public bool CheckDUI()
        {
            try
            {
                //Conexion con la base
                command.Connection = getConnection();
                //query de la consulta
                string query = "SELECT * FROM tbEmployee WHERE DUI = @param1 AND username != @username";
                //Creamos el comando SQL con la conexión y la base.
                SqlCommand cmd = new SqlCommand(query, command.Connection);
                //Damos valor a los parámetros
                cmd.Parameters.AddWithValue("param1", Dui);
                cmd.Parameters.AddWithValue("username", Username);
                //Ejecutamos el comando
                cmd.ExecuteNonQuery();
                //Creamos un dataReader
                SqlDataReader rd = cmd.ExecuteReader();
                while (rd.Read())
                {
                    string DUI = rd.GetString(3);
                }
                return rd.HasRows;
            }
            catch (SqlException ex)
            {
                MessageBox.Show("EC-022: No se pudo obtener los datos de los empleados", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            finally
            {
                command.Connection.Close();
            }
        }

        public bool CheckEmail()
        {
            try
            {
                //Conexion con la base
                command.Connection = getConnection();
                //query de la consulta
                string query = "SELECT * FROM tbEmployee WHERE email = @param1 AND username != @username";
                //Creamos el comando SQL con la conexión y la base.
                SqlCommand cmd = new SqlCommand(query, command.Connection);
                //Damos valor a los parámetros
                cmd.Parameters.AddWithValue("param1", Email);
                cmd.Parameters.AddWithValue("username", Username);
                //Ejecutamos el comando
                cmd.ExecuteNonQuery();
                //Creamos un dataReader
                SqlDataReader rd = cmd.ExecuteReader();
                while (rd.Read())
                {
                    string e = rd.GetString(5);
                }
                return rd.HasRows;
            }
            catch (SqlException ex)
            {
                MessageBox.Show("EC-022: No se pudo obtener los datos de los empleados", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            finally
            {
                command.Connection.Close();
            }
        }

        public bool ReadNewCredentials()
        {
            try
            {
                command.Connection = getConnection();
                string query = "SELECT * FROM viewLogIn WHERE username = @username";
                SqlCommand cmd = new SqlCommand(query, command.Connection);
                cmd.Parameters.AddWithValue("username", Username);
                SqlDataReader rd = cmd.ExecuteReader();
                while (rd.Read())
                {
                    SessionVar.Username = rd.GetString(0);
                    SessionVar.Password = rd.GetString(1);
                    SessionVar.IdBussinesP = rd.GetInt32(3);
                    SessionVar.Access = rd.GetString(4);
                    SessionVar.FullName = rd.GetString(5);
                    if (!rd.IsDBNull(6))
                    {
                        long size = rd.GetBytes(6, 0, null, 0, 0);
                        byte[] profilePic = new byte[size];
                        rd.GetBytes(6, 0, profilePic, 0, (int)size);
                        SessionVar.ProfilePic = profilePic;
                    }
                    else
                    {
                        SessionVar.ProfilePic = null; // Asignar null si el valor en la base de datos es null
                    }
                    SessionVar.Phone = rd.GetString(7);
                    SessionVar.Email = rd.GetString(8);
                }
                return rd.HasRows;
            }
            catch (SqlException sqlex)
            {
                MessageBox.Show("EC-006: No se pudieron obtener los datos para el logIn");
                return false;
            }
            finally
            {
                getConnection().Close();
            }
        }
    }
}
