using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PTC2024.Model.DTO;
using PTC2024.Model.DTO.LogInDTO;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Web.Hosting;

namespace PTC2024.Model.DAO.LogInDAO
{
    internal class DAORegister:DTORegister
    {
        readonly SqlCommand command = new SqlCommand();

        public int GetNames()
        {
            try
            {
                command.Connection = getConnection();
                string queryUser = "INSERT INTO tbEmployee VALUES (@names, @lastName, @birthDate,@Email,@DUI,@phone,@address) ";

                SqlCommand cmdInsert = new SqlCommand(queryUser, command.Connection);

                cmdInsert.Parameters.AddWithValue("DUI", DUI1);
                cmdInsert.Parameters.AddWithValue("birthDate", Birth1);
                cmdInsert.Parameters.AddWithValue("Email", Email);
                cmdInsert.Parameters.AddWithValue("phone", Phone);
                cmdInsert.Parameters.AddWithValue("address", Address);
                cmdInsert.Parameters.AddWithValue("lastName", Lastnames);
                cmdInsert.Parameters.AddWithValue("names", Names);
               
                
              

                int respuesta = cmdInsert.ExecuteNonQuery();

                if (respuesta ==1)
                {

                    string queryPerson = "INSERT INTO tbUserData VALUES (@username, @password)";
                    SqlCommand cmdInsertData = new SqlCommand(queryPerson, command.Connection);
                    cmdInsertData.Parameters.AddWithValue("username", User);
                    cmdInsertData.Parameters.AddWithValue("password", Password);
                    // falta agregar la tabla en base de datos cmdInsertData.Parameters.AddWithValue("confirmPassword", ConfirmPassword);
                    respuesta = cmdInsertData.ExecuteNonQuery();

                    if (respuesta == 1)
                    {
                        return 1;
                    }

                    else
                    {
                        return 0;
                    }
                }
                else
                {
                    return 0;
                }

            }
            catch (SqlException ex)
            {

                MessageBox.Show($"{ex.Message}EC-005 ERROR BELLAKO: No se puedieron obtener los datos de los Nombres del usuario  ");
                return -1;
            }
            finally
            {
                command.Connection.Close();
            }
        


        }
    }
}
