using PTC2024.Controller.Helper;
using PTC2024.Model.DTO.StartMenuDTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PTC2024.Model.DAO.StartMenuDAO
{
    internal class DAOStartMenu : DTOStartMenu
    {
        readonly SqlCommand command = new SqlCommand();

        //método para verificar que el token del usuario es el mismo que existe de forma local.
        public bool CompararToken()
        {
            try
            {
                //conexion
                command.Connection = getConnection();
                //query
                string query = "SELECT * FROM tbUserData WHERE username = @username AND rememberToken = @savedToken AND tokenExpiry > @currentDate";
                //Comando SQL con conexión y el query
                SqlCommand cmd = new SqlCommand(query, command.Connection);
                //damos valor a los parametros
                cmd.Parameters.AddWithValue("username", Username);
                cmd.Parameters.AddWithValue("savedToken", Token);
                cmd.Parameters.AddWithValue("currentDate", CurrentDate);
                //creamos un reader
                SqlDataReader rd = cmd.ExecuteReader();
                //devolvemos si el reader encontró algun registro
                return rd.HasRows;
            }
            catch (Exception ex)
            {
                MessageBox.Show("EC-009: No se pudieron obtener los datos de ususario para comparar el token", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            finally
            {
                command.Connection.Close();
            }
        } 
        public bool ChargeInfoBusiness()
        {
            try
            {
                command.Connection = getConnection();
                string query = "SELECT * FROM tbBusinessInfo";
                SqlCommand cmd = new SqlCommand(query,command.Connection);
                SqlDataReader rd = cmd.ExecuteReader();
                while (rd.Read())
                {
                    BusinessVar.IdBusiness = rd.GetInt32(0);
                    BusinessVar.BusinessName = rd.GetString(1);
                    BusinessVar.BusinessAdress = rd.GetString(2);
                    BusinessVar.BusinessEmail = rd.GetString(3);
                    BusinessVar.BusinessPhone = rd.GetString(5);
                    BusinessVar.BusinessPBX = rd.GetString(6);
                    if (!rd.IsDBNull(7))
                    {
                        long size = rd.GetBytes(7, 0, null, 0, 0);
                        byte[] profilePic = new byte[size];
                        rd.GetBytes(7, 0, profilePic, 0, (int)size);
                        BusinessVar.BusinessImg = profilePic;
                    }
                    else
                    {
                        BusinessVar.BusinessImg = null; // Asignar null si el valor en la base de datos es null
                    }
                }
                return rd.HasRows;
            }
            catch (SqlException sqlex)
            {
                MessageBox.Show("EC-135: No se pudieron obtener los datos del negocio");
                return false;
            }
            finally
            {
                getConnection().Close();
            }
        }
        public int DeleteUserToken()
        {
            try
            {
                command.Connection = getConnection();
                string query = "UPDATE tbUserData SET " +
                               "rememberToken = @param1, " +
                               "tokenExpiry = @param2 " +
                               "WHERE username = @param3";
                SqlCommand cmd = new SqlCommand(query, command.Connection);
                cmd.Parameters.AddWithValue("param1", "");
                cmd.Parameters.AddWithValue("param2", "");
                cmd.Parameters.AddWithValue("param3", Username);
                return cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
                return -1;
            }
            catch (Exception)
            {
                MessageBox.Show("EC-010: No se pudo actualizar el token del usuario", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }
            finally
            {
                command.Connection.Close();
            }
        }
    }
}
