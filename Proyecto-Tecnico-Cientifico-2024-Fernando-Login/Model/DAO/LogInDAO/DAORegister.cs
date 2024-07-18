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
                string queryPerson = "INSERT INTO tbUserData VALUES (@username, @password, @business)";
                SqlCommand cmdInsertData = new SqlCommand(queryPerson, command.Connection);
                cmdInsertData.Parameters.AddWithValue("username", User);
                cmdInsertData.Parameters.AddWithValue("password", Password);
                cmdInsertData.Parameters.AddWithValue("business", BusinessP);
               
                // falta agregar la tabla en base de datos cmdInsertData.Parameters.AddWithValue("confirmPassword", ConfirmPassword);



                int respuesta = cmdInsertData.ExecuteNonQuery();

                if (respuesta == 1)
                {

                    string queryUser = "INSERT INTO tbEmployee VALUES (@DUI, @birthDate, @Email,@phone,@address,@lastName,@names, @department, @typeE, @maritalStatus,@status) ";

                    SqlCommand cmdInsert = new SqlCommand(queryUser, command.Connection);

                    cmdInsert.Parameters.AddWithValue("DUI", DUI1);
                    cmdInsert.Parameters.AddWithValue("birthDate", Birth);
                    cmdInsert.Parameters.AddWithValue("Email", Email);
                    cmdInsert.Parameters.AddWithValue("phone", Phone);
                    cmdInsert.Parameters.AddWithValue("address", Address);
                    cmdInsert.Parameters.AddWithValue("lastName", Lastnames);
                    cmdInsert.Parameters.AddWithValue("names", Names);
                    cmdInsertData.Parameters.AddWithValue("department", Department);
                    cmdInsertData.Parameters.AddWithValue("typeE", TypeE);
                    cmdInsertData.Parameters.AddWithValue("maritalStatus", MaritalStatus);
                    cmdInsertData.Parameters.AddWithValue("status", MaritalStatus);
                    respuesta = cmdInsert.ExecuteNonQuery();

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
    
