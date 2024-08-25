using PTC2024.Controller.Helper;
using PTC2024.Model.DTO.LogInDTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
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
                string query = "SELECT * FROM viewLogIn WHERE username = @username COLLATE SQL_Latin1_General_CP1_CS_AS AND password = @password COLLATE SQL_Latin1_General_CP1_CS_AS AND userStatus = @status AND username = @username AND password = @password";
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

        public bool ValidateTemporalPassword()
        {
            try
            {
                //Conexion con la base
                command.Connection = getConnection();
                //Creamos el query
                string query = "SELECT * FROM viewLogIn WHERE username = @username COLLATE SQL_Latin1_General_CP1_CS_AS AND password = @password COLLATE SQL_Latin1_General_CP1_CS_AS AND userStatus = @status AND username = @username AND password = @password";
                //Comando con la conexión y el query
                SqlCommand cmd = new SqlCommand(query, command.Connection);
                //damos valor a los parámetros
                cmd.Parameters.AddWithValue("username", Username);
                cmd.Parameters.AddWithValue("password", Password);
                cmd.Parameters.AddWithValue("status", UserStatus);
                //Creamos un DataReader y lo ejecutamos
                SqlDataReader rd = cmd.ExecuteReader();
                //Creamos la variable que va a capturar el dato
                bool temporalP = false;
                while (rd.Read())
                {
                    temporalP = rd.GetBoolean(9);
                }
                //Retornamos la variable que contiene lo que esta en la columna de la vista
                return temporalP;
            }
            catch (SqlException ex)
            {
                //Si algo sale mal retornamos un false
                MessageBox.Show(ex.Message);
                return false;
            }
            finally
            {
                command.Connection.Close();
            }
        }

    }
}
