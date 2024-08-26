using PTC2024.Model.DTO.PasswordRecoverDTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PTC2024.Model.DAO.PasswordRecoverDAO
{
    internal class DAONextQuestionsMetod : DTONextQuestionsMetod
    {
        //Creamos el command
        readonly SqlCommand command = new SqlCommand();

        //Método para verificar las respuestas
        public bool ValidateAnswers()
        {
            try
            {
                //Creamos la conexión
                command.Connection = getConnection();
                //Creamos el query de la consulta
                string query = "SELECT * FROM viewQuestionsRecover WHERE firstQuestion = @firstQ AND secondQuestion = @secondQ AND thirdQuestion = @thirdQ AND username = @username";
                //Creamos el comando Sql con la conexion y el query
                SqlCommand cmd = new SqlCommand(query, command.Connection);
                //Damos valor a los parámetros
                cmd.Parameters.AddWithValue("firstQ", FirstAnswer);
                cmd.Parameters.AddWithValue("secondQ", SecondAnswer);
                cmd.Parameters.AddWithValue("thirdQ", ThirdAnswer);
                cmd.Parameters.AddWithValue("username", Username);
                //ejecutamos el comando
                cmd.ExecuteNonQuery();
                //Creamos el dataReader
                SqlDataReader rd = cmd.ExecuteReader();
                while (rd.Read())
                {
                    string username = rd.GetString(0);
                    string firstAnswer = rd.GetString(1);
                    string secondAnswer = rd.GetString(2);
                    string thirdAnswer = rd.GetString(3);
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
