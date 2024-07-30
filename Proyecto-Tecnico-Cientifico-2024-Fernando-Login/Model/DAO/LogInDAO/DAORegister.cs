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
                //Consulto si el usuario existe
                command.Connection = getConnection();
                string queryUserExist = "select username from dbo.tbUserData where username=@username";
                SqlCommand cmdUserExist= new SqlCommand(queryUserExist, command.Connection);
                cmdUserExist .Parameters.AddWithValue("username", User);
                DataTable dt=new DataTable();
                SqlDataAdapter adapter = new SqlDataAdapter(cmdUserExist);
                adapter.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    MessageBox.Show("Usuario ya Existe");
                    return 1;
                }
              

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

                    string queryUser = "INSERT INTO tbEmployee (DUI,birthDate,email,phone,address,lastName,names,username,IdDepartment,IdTypeE,IdMaritalS,IdStatus) VALUES (@DUI, @birthDate, @Email,@phone,@address,@lastName,@names,@username ,@IdDepartment, @IdTypeE, @IdMaritalS,@IdStatus) ";

                    SqlCommand cmdInsert = new SqlCommand(queryUser, command.Connection);

                    cmdInsert.Parameters.AddWithValue("DUI", DUI1);
                    cmdInsert.Parameters.AddWithValue("birthDate", Birth);
                    cmdInsert.Parameters.AddWithValue("email", Email);
                    cmdInsert.Parameters.AddWithValue("phone", Phone);
                    cmdInsert.Parameters.AddWithValue("address", Address);
                    cmdInsert.Parameters.AddWithValue("lastName", Lastnames);
                    cmdInsert.Parameters.AddWithValue("names", Names);
                    cmdInsert.Parameters.AddWithValue("userName",User );
                    cmdInsert.Parameters.AddWithValue("IdDepartment", Department);
                    cmdInsert.Parameters.AddWithValue("IdTypeE", TypeE);
                    cmdInsert.Parameters.AddWithValue("IdMaritalS", MaritalStatus);
                    cmdInsert.Parameters.AddWithValue("IdStatus", Status);
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
    
