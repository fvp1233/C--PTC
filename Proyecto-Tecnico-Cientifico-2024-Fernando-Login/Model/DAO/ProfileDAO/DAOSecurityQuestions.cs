using PTC2024.Model.DTO.ProfileDTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PTC2024.Model.DAO.ProfileDAO
{
    internal class DAOSecurityQuestions : DTOSecurityQuestions
    {
        //Creamos el command
        readonly SqlCommand command = new SqlCommand();

        //Método para insertar las respuestas de las preguntas
        public int InsertAnswers()
        {
            try
            {
                //conexion con la base
                command.Connection = getConnection();
                //query con la consulta
                string query = "INSERT INTO tbSecurityQuestions(firstQuestion, secondQuestion, thirdQuestion, username) VALUES (@firstQ, @secondQ, @thirdQ, @username)";
                //Comando Sql con la conexion y el query
                SqlCommand cmd = new SqlCommand(query, command.Connection);
                //Damos valor a los parámetros del cmd
                cmd.Parameters.AddWithValue("firstQ", FirstQ);
                cmd.Parameters.AddWithValue("secondQ", SecondQ);
                cmd.Parameters.AddWithValue("thirdQ", ThirdQ);
                cmd.Parameters.AddWithValue("username", Username);
                //ejecutamos la consulta
                int answer = cmd.ExecuteNonQuery();
                //devolvemos la respuesta 
                return answer;
            }
            catch (SqlException ex)
            {
                MessageBox.Show("EC-014: No se pudieron insertar las preguntas de seguridad", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }
            finally
            {
                command.Connection.Close();
            }
        }

    }
}
