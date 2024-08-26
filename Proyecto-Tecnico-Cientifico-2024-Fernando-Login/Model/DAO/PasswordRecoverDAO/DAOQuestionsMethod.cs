using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using System.Windows.Forms;
using PTC2024.Model.DTO.PasswordRecoverDTO;

namespace PTC2024.Model.DAO.PasswordRecoverDAO
{
    internal class DAOQuestionsMethod : DTOQuestionsMethod
    {
        //Creamos el command
        readonly SqlCommand command = new SqlCommand();

        //Método para verificar si el usuario posee respuestas de seguridad
        public bool CheckSecurityQ()
        {
            try
            {
                //Conexion con la base
                command.Connection = getConnection();
                //El query de la consulta
                string query = "SELECT * FROM viewQuestionsRecover WHERE username  = @username ";
                //comando sql con conexion y query
                SqlCommand cmd = new SqlCommand(query, command.Connection);
                //le damos valor a los parámetros
                cmd.Parameters.AddWithValue("username", Username);
                //ejecutamos el comando
                cmd.ExecuteNonQuery();
                //Creamos un dataReader
                SqlDataReader rd = cmd.ExecuteReader();
                while (rd.Read())
                {
                    string username = rd.GetString(0);
                    string firstQ = rd.GetString(1);
                    string secondQ = rd.GetString(2);
                    string thirdQ = rd.GetString(3);
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
                cmd.Parameters.AddWithValue("username", Username);
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
    }
}
