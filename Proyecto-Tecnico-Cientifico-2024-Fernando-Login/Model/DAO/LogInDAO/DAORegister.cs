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
    internal class DAORegister : DTORegister
    {
        readonly SqlCommand command = new SqlCommand();

        public DataSet ObtenerBanco()
        {
            try
            {
                command.Connection = getConnection();
                string query = "SELECT*FROM tbBanks";
                SqlCommand cmd = new SqlCommand(query, command.Connection);
                cmd.ExecuteNonQuery();

                //El adaptador recibe la info que encontró el "cmd"
                SqlDataAdapter adp = new SqlDataAdapter(cmd);

                //el siguiente dataset va a ser el que el método va a devolver
                DataSet ds = new DataSet();

                //se llena el dataset "ds" con la información que recibió el adaptador "adp"
                adp.Fill(ds, "tbBanks");

                //se devuelve el dataset
                return ds;

            }
            catch (SqlException ex)
            {
                MessageBox.Show("EC-002: No se puedieron obtener los datos de los Diferentes Bancos");
                return null;
            }
            finally
            {
                command.Connection.Close();
            }
        }
        public int GetNames()
        {
            try
            {
                //Consulto si el usuario existe
                command.Connection = getConnection();
                string queryUserExist = "select username from dbo.tbUserData where username=@username";
                SqlCommand cmdUserExist = new SqlCommand(queryUserExist, command.Connection);
                cmdUserExist.Parameters.AddWithValue("username", User);
                DataTable dt = new DataTable();
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

                    string queryUser = "INSERT INTO tbEmployee (names,lastName,DUI,birthDate,email,phone,address,salary,bankAccount,affiliationNumber, hireDate,IdBank,IdDepartment,IdTypeE,IdMaritalS,IdStatus,username) VALUES (@names,@lastName,@DUI,@birthDate,@email,@phone,@address,@salary,@bankAccount,@affiliationNumber,@hireDate,@IdBank,@IdDepartment,@IdTypeE,@IdMaritalS,@IdStatus,@username)";

                    SqlCommand cmdInsert = new SqlCommand(queryUser, command.Connection);

                    cmdInsert.Parameters.AddWithValue("names", Names);
                    cmdInsert.Parameters.AddWithValue("lastName", Lastnames);
                    cmdInsert.Parameters.AddWithValue("DUI", DUI1);
                    cmdInsert.Parameters.AddWithValue("birthDate", Birth);
                    cmdInsert.Parameters.AddWithValue("email", Email);
                    cmdInsert.Parameters.AddWithValue("phone", Phone);
                    cmdInsert.Parameters.AddWithValue("address", Address);
                    cmdInsert.Parameters.AddWithValue("salary", Salary);
                    cmdInsert.Parameters.AddWithValue("bankAccount", BankAccount);
                    cmdInsert.Parameters.AddWithValue("affiliationNumber", AffiliationNumber);
                    cmdInsert.Parameters.AddWithValue("hireDate", HireDate);
                    cmdInsert.Parameters.AddWithValue("IdBank", BankType);
                    cmdInsert.Parameters.AddWithValue("IdDepartment", Department);
                    cmdInsert.Parameters.AddWithValue("IdTypeE", TypeE);
                    cmdInsert.Parameters.AddWithValue("IdMaritalS", MaritalStatus);
                    cmdInsert.Parameters.AddWithValue("IdStatus", Status);
                    cmdInsert.Parameters.AddWithValue("userName", User);
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
                if (respuesta == 1)
                {
                    string queryUser = "INSERT INTO tbBanks (BankName) VALUES (@BankName)";

                    SqlCommand cmdInsert = new SqlCommand(queryUser, command.Connection);

                    cmdInsert.Parameters.AddWithValue("BankName", BankType);

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

