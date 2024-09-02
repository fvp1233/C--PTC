using PTC2024.Controller.Helper;
using PTC2024.Model.DTO.HelperDTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PTC2024.Model.DAO.HelperDAO
{
    internal class DAOInitialView : DTOInitialView
    {
        //Creamos el command
        readonly SqlCommand command = new SqlCommand();

        //Método para comparar el token local y el de la base de datos y verificar si existe un usuario que activó el remember me, teniendo en cuenta su fecha de expiración
        public bool CompararToken()
        {
            try
            {
                //conexion
                command.Connection = getConnection();
                //query
                string query = "SELECT * FROM tbUserData WHERE rememberToken = @savedToken AND tokenExpiry > @currentDate";
                //Comando SQL con conexión y el query
                SqlCommand cmd = new SqlCommand(query, command.Connection);
                //damos valor a los parametros
                cmd.Parameters.AddWithValue("savedToken", Token);
                cmd.Parameters.AddWithValue("currentDate", CurrentDate);
                //creamos un reader
                SqlDataReader rd = cmd.ExecuteReader();
                //devolvemos si el reader encontró algun registro
                return rd.HasRows;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
            finally
            {
                command.Connection.Close();
            }
            

        }

        public bool GetCredentials()
        {
            try
            {
                command.Connection = getConnection();
                string query = "SELECT * FROM viewLogIn WHERE rememberToken = @savedToken";
                SqlCommand cmd = new SqlCommand(query, command.Connection);
                cmd.Parameters.AddWithValue("savedToken", Token);
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
    }
}
