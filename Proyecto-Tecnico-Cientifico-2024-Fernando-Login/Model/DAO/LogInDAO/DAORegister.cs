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
using PTC2024.View.login;

namespace PTC2024.Model.DAO.LogInDAO
{
    internal class DAORegister : DTORegister
    {
        readonly SqlCommand command = new SqlCommand();

        public DataSet ObtainBanks()
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

        public DataSet ObtainGenders()
        {
            try
            {
                command.Connection = getConnection();
                string query = "SELECT * FROM tbGenders";
                SqlCommand cmd = new SqlCommand(query, command.Connection);
                cmd.ExecuteNonQuery();
                //creamos adp que recibe la info del cmd
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                //creamos el data set
                DataSet ds = new DataSet();
                //llenamos el dataset
                adp.Fill(ds, "tbGenders");
                //devolvemos el dataset
                return ds;
            }
            catch (SqlException ex)
            {
                MessageBox.Show("EC-002: No se puedieron obtener los datos de los Diferentes Bancos");
                MessageBox.Show(ex.Message);
                return null;
            }
            finally
            {
                command.Connection.Close();
            }
        }

        public int EmployeeRegister()
        {
            try
            {
                //Abrimos conexión con la base
                command.Connection= getConnection();
                //Creamos el query para introducir primeramente a la tabla tbUserData
                string queryInsertUser = "INSERT INTO tbUserData(username, password, IdBusinessP, userStatus, idBusiness, temporalpassword) VALUES (@username, @password, @IdBusinessP, @userStatus, @idBusiness, @temporalP)";
                //Creamos el comando SQL que tendrá la el query y la conexión a la base
                SqlCommand cmdInsertUser = new SqlCommand(@queryInsertUser, command.Connection);
                //Le asignamos un valor a los parámetros del query con los métodos getter
                cmdInsertUser.Parameters.AddWithValue("username", Username);
                cmdInsertUser.Parameters.AddWithValue("password", Password);
                cmdInsertUser.Parameters.AddWithValue("IdBusinessP", BusinessPosition);
                cmdInsertUser.Parameters.AddWithValue("userStatus", UserSatus);
                cmdInsertUser.Parameters.AddWithValue("idBusiness", BusinessInfo);
                cmdInsertUser.Parameters.AddWithValue("temporalP", false);
                //Creamos una variable int que nos servirá para saber si el registro se ingresó o no.
                int registerUserAnswer = cmdInsertUser.ExecuteNonQuery();

                if (registerUserAnswer == 1)
                {
                    //Si la respuesta es 1, entonces el usuario se ingresó correctamente, por lo que ahora ingresaremos al empleado
                    //creamos el query
                    string queryInsertEmployee = "INSERT INTO tbEmployee(names, lastName, DUI, birthDate, email, phone, address, salary, bankAccount, affiliationNumber, hireDate, IdBank, IdDepartment, IdTypeE, IdMaritalS, IdStatus, username, IdGender) VALUES (@param1, @param2, @param3, @param4, @param5, @param6, @param7, @param8, @param9, @param10, @param11, @param12, @param13, @param14, @param15, @param16, @param17, @param18)";
                    //Creamos el comando SQL con la conexión y el query
                    SqlCommand cmdInsertEmployee = new SqlCommand(queryInsertEmployee, command.Connection);
                    //Le damos el valor a todos los parámetros con los métodos getter y setter
                    cmdInsertEmployee.Parameters.AddWithValue("param1", Names);
                    cmdInsertEmployee.Parameters.AddWithValue("param2", LastNames);
                    cmdInsertEmployee.Parameters.AddWithValue("param3", Document);
                    cmdInsertEmployee.Parameters.AddWithValue("param4", BirthDate);
                    cmdInsertEmployee.Parameters.AddWithValue("param5", Email);
                    cmdInsertEmployee.Parameters.AddWithValue("param6", Phone);
                    cmdInsertEmployee.Parameters.AddWithValue("param7", Address);
                    cmdInsertEmployee.Parameters.AddWithValue("param8", Salary);
                    cmdInsertEmployee.Parameters.AddWithValue("param9", BankAccount);
                    cmdInsertEmployee.Parameters.AddWithValue("param10", AffiliationNumber);
                    cmdInsertEmployee.Parameters.AddWithValue("param11", HireDate);
                    cmdInsertEmployee.Parameters.AddWithValue("param12", Bank);
                    cmdInsertEmployee.Parameters.AddWithValue("param13", Department);
                    cmdInsertEmployee.Parameters.AddWithValue("param14", EmployeeType);
                    cmdInsertEmployee.Parameters.AddWithValue("param15", MaritalStatus);
                    cmdInsertEmployee.Parameters.AddWithValue("param16", EmployeeStatus);
                    cmdInsertEmployee.Parameters.AddWithValue("param17", Username);
                    cmdInsertEmployee.Parameters.AddWithValue("param18", Gender);

                    //Creamos una variable int para saber si el empleado fue ingresado o no
                    int registerEmployeeAnswer = cmdInsertEmployee.ExecuteNonQuery();
                    if (registerEmployeeAnswer == 1)
                    {
                        //Si la respuesta es 1, entonces el empleado si se registró y el proceso se completó
                        return registerEmployeeAnswer;
                    }
                    else
                    {
                        //Si la respuesta no es 1, significa que el empleado no se registró, entonces tenemos que eliminar el usuario que se le había creado con anterioridad con el método RollBack y regresamos un 0.
                        RollBack();
                        return 0;
                    }
                }
                else
                {
                    //si el usuario no se ingresó, entonces retornamos un 0
                    MessageBox.Show("Hubo un error al ingresar el usuario o este ya es existente", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return 0;
                }
            }
            catch (SqlException sqlEx)
            {
                MessageBox.Show(sqlEx.Message);
                return -1;
            }
            catch (Exception ex)
            {
                //retornamos un -1 si algo salió mal en el try
                MessageBox.Show(ex.Message);
                return -1;
            }

        }

        public void RollBack()
        {
            string queryDeleteUser = "DELETE FROM tbUserData WHERE username = @username";
            SqlCommand cmdDeleteUser = new SqlCommand(queryDeleteUser, command.Connection);
            cmdDeleteUser.Parameters.AddWithValue("username", Username);
            int returnValue = cmdDeleteUser.ExecuteNonQuery();
        }

        #region CÓDIGO ANTERIOR
        //public int GetNames()
        //{
        //    try
        //    {
        //        //Consulto si el usuario existe
        //        command.Connection = getConnection();
        //        string queryUserExist = "select username from dbo.tbUserData where username=@username";
        //        SqlCommand cmdUserExist = new SqlCommand(queryUserExist, command.Connection);
        //        cmdUserExist.Parameters.AddWithValue("username", User);
        //        DataTable dt = new DataTable();
        //        SqlDataAdapter adapter = new SqlDataAdapter(cmdUserExist);
        //        adapter.Fill(dt);

        //        if (dt.Rows.Count > 0)
        //        {
        //            MessageBox.Show("Usuario ya Existe");
        //            return 1;
        //        }


        //        command.Connection = getConnection();
        //        string queryPerson = "INSERT INTO tbUserData VALUES (@username, @password, @IdbusinessP,@IdStatus)";
        //        SqlCommand cmdInsertData = new SqlCommand(queryPerson, command.Connection);
        //        cmdInsertData.Parameters.AddWithValue("username", User);
        //        cmdInsertData.Parameters.AddWithValue("password", Password);
        //        cmdInsertData.Parameters.AddWithValue("IdbusinessP", BusinessP);
        //        cmdInsertData.Parameters.AddWithValue("IdStatus", UserStatus);


        //        int respuesta = cmdInsertData.ExecuteNonQuery();

        //        if (respuesta == 1)
        //        {

        //            string queryUser = "INSERT INTO tbEmployee (names,lastName,DUI,birthDate,email,phone,address,salary,bankAccount,affiliationNumber, hireDate,IdBank,IdDepartment,IdTypeE,IdMaritalS,IdStatus,username) VALUES (@names,@lastName,@DUI,@birthDate,@email,@phone,@address,@salary,@bankAccount,@affiliationNumber,@hireDate,@IdBank,@IdDepartment,@IdTypeE,@IdMaritalS,@IdStatus,@username)";

        //            SqlCommand cmdInsert = new SqlCommand(queryUser, command.Connection);

        //            cmdInsert.Parameters.AddWithValue("names", Names);
        //            cmdInsert.Parameters.AddWithValue("lastName", Lastnames);
        //            cmdInsert.Parameters.AddWithValue("DUI", DUI1);
        //            cmdInsert.Parameters.AddWithValue("birthDate", Birth);
        //            cmdInsert.Parameters.AddWithValue("email", Email);
        //            cmdInsert.Parameters.AddWithValue("phone", Phone);
        //            cmdInsert.Parameters.AddWithValue("address", Address);
        //            cmdInsert.Parameters.AddWithValue("salary", Salary);
        //            cmdInsert.Parameters.AddWithValue("bankAccount", BankAccount);
        //            cmdInsert.Parameters.AddWithValue("affiliationNumber", AffiliationNumber);
        //            cmdInsert.Parameters.AddWithValue("hireDate", HireDate);
        //            cmdInsert.Parameters.AddWithValue("IdBank", BankType);
        //            cmdInsert.Parameters.AddWithValue("IdDepartment", Department);
        //            cmdInsert.Parameters.AddWithValue("IdTypeE", TypeE);
        //            cmdInsert.Parameters.AddWithValue("IdMaritalS", MaritalStatus);
        //            cmdInsert.Parameters.AddWithValue("IdStatus", Status);
        //            cmdInsert.Parameters.AddWithValue("userName", User);
        //            respuesta = cmdInsert.ExecuteNonQuery();

        //            if (respuesta == 1)
        //            {
        //                return 1;
        //            }

        //            else
        //            {
        //                return 0;
        //            }
        //        }
        //        else
        //        {
        //            return 0;
        //        }
        //        if (respuesta == 1)
        //        {
        //            string queryUser = "INSERT INTO tbBanks (BankName) VALUES (@BankName)";

        //            SqlCommand cmdInsert = new SqlCommand(queryUser, command.Connection);

        //            cmdInsert.Parameters.AddWithValue("BankName", BankType);

        //            if (respuesta == 1)
        //            {

        //                return 1;


        //            }

        //            else
        //            {
        //                return 0;
        //            }
        //        }
        //        else
        //        {
        //            return 0;
        //        }


        //    }




        //    catch (SqlException ex)
        //    {

        //        MessageBox.Show($"{ex.Message}EC-005  No se puedieron ingresar los datos de los datos del usuario  ");
        //        return -1;
        //    }
        //    finally
        //    {
        //        command.Connection.Close();
        //    }



        //}
        #endregion
    }
}

