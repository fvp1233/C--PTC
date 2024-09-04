using PTC2024.Model.DTO.AlertsDTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PTC2024.Controller.Helper;
using System.Windows.Forms;

namespace PTC2024.Model.DAO.AlertsDAO
{
    internal class DAOChangePassword : DTOChangePassword
    {
        readonly SqlCommand command = new SqlCommand();

        //Método para inserción de la nueva contraseña
        public int ChangePassword()
        {
            try
            {
                //Abrimos conexión con la base
                command.Connection = getConnection();
                //Creamos el query con las instrucciones para la base
                string query = "UPDATE tbUserData SET password = @param1, temporalpassword = @temporalP WHERE username = @param2";
                //Creamos el comando que tendrá el query con la conexión 
                SqlCommand cmd = new SqlCommand(query, command.Connection);
                //Asignamos los valores a los parámetros
                cmd.Parameters.AddWithValue("param1", Password);
                cmd.Parameters.AddWithValue("temporalP", false);
                cmd.Parameters.AddWithValue("param2", Username);
                //Creamos la variable que nos dirá si el proceso se completó o no
                int answer = cmd.ExecuteNonQuery();
                //retornamos esa variable
                return answer;
            }
            catch (SqlException ex)
            {
                //Si algo sale mal en el try, retornamos un -1
                MessageBox.Show("EC-130: No se pudo obtener la información del usuario", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
                
            }
            finally
            {
                command.Connection.Close();
            }
        }
    }
}
