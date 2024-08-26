using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using PTC2024.Model.DTO.ProfileDTO;
using System.Windows.Forms;

namespace PTC2024.Model.DAO.ProfileDAO
{
    internal class DAOProfile : DTOProfile
    {
        readonly SqlCommand command = new SqlCommand();

        public DataSet GetEmployee()
        {
            try
            {
                command.Connection = getConnection();
                string queryEmployee = "SELECT * FROM tbEmployee ";
                SqlCommand cmdEmployeeInfo = new SqlCommand(@queryEmployee, command.Connection);
                cmdEmployeeInfo.ExecuteNonQuery();
                SqlDataAdapter adp = new SqlDataAdapter(cmdEmployeeInfo);
                DataSet ds = new DataSet();
                adp.Fill(ds, "tbEmployee");
                return ds;
            }
            catch (Exception)
            {
                return null;
            }
            finally
            {
                getConnection().Close();
            }
        }

        public int SaveInfo()
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
                MessageBox.Show($"Excepcion SQL: {ex.Message}", "Error al procesar información", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
            finally
            {
                command.Connection.Close();
            }
        }

        //Método para verificar si el usuario ya tiene preguntas de seguridad contestadas
        public bool CheckSecurityQ()
        {
            try
            {
                //Conexion con la base
                command.Connection = getConnection();
                //El query de la consulta
                string query = "SELECT * FROM viewQuestionsRecover WHERE username = @username";
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
        
        //método para eliminar las respuestas existentes en caso de que el usuario quiera volver a contestarlas.        
        public int DeleteSecurityQ()
        {
            try
            {
                //Conexion con la base
                command.Connection = getConnection();
                //query de la consulta
                string query = "DELETE FROM tbSecurityQuestions WHERE username = @username";
                //comando sql con el query y la conexion
                SqlCommand cmd = new SqlCommand(query, command.Connection);
                //damos valor a los parámetros de la consulta
                cmd.Parameters.AddWithValue("username", Username);
                //Ejecutamos el comando
                int answer = cmd.ExecuteNonQuery();
                //retornamos la respuesta
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
