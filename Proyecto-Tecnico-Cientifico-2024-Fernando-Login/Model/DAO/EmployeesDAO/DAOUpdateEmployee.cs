using PTC2024.Model.DTO.EmployeesDTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.ComponentModel.Design.ObjectSelectorEditor;

namespace PTC2024.Model.DAO.EmployeesDAO
{
    internal class DAOUpdateEmployee : DTOUpdateEmployee
    {
        readonly SqlCommand Command = new SqlCommand();

        public int UpdateEmployee()
        {
            try
            {
                //Se crea la conexión a la base
                Command.Connection = getConnection();

                //Se crea el query para actualizar al empleado 
                string queryUpdateE = "UPDATE tbEmployee SET " +
                                       "names = @param1, " +
                                       "lastName = @param2, " +
                                       "DUI = @param3, " +
                                       "birthDate = @param4, " +
                                       "email = @param5, " +
                                       "phone = @param6, " +
                                       "address = @param7, " +
                                       "salary = @param8, " +
                                       "bankAccount = @param9, " +
                                       "affiliationNumber = @param10, " +
                                       "hireDate = @param11, " +
                                       "IdBank = @param12, " +
                                       "IdDepartment = @param13, " +
                                       "IdTypeE = @param14, " +
                                       "IdMaritalS = @param15, " +
                                       "IdStatus = @param16 " +
                                       "WHERE IdEmployee = @idEmployee";
                //Se crea el comando Sql que tendrá el query y la conexión
                SqlCommand cmdUpdateE = new SqlCommand(queryUpdateE, Command.Connection);
                //Se le agregan los valores a los parámeros
                cmdUpdateE.Parameters.AddWithValue("param1", Names);
                cmdUpdateE.Parameters.AddWithValue("param2", LastNames);
                cmdUpdateE.Parameters.AddWithValue("param3", Document);
                cmdUpdateE.Parameters.AddWithValue("param4", BirthDate);
                cmdUpdateE.Parameters.AddWithValue("param5", Email);
                cmdUpdateE.Parameters.AddWithValue("param6", Phone);
                cmdUpdateE.Parameters.AddWithValue("param7", Address);
                cmdUpdateE.Parameters.AddWithValue("param8", Salary);
                cmdUpdateE.Parameters.AddWithValue("param9", BankAccount);
                cmdUpdateE.Parameters.AddWithValue("param10", AffiliationNumber);
                cmdUpdateE.Parameters.AddWithValue("param11", HireDate);
                cmdUpdateE.Parameters.AddWithValue("param12", Bank);
                cmdUpdateE.Parameters.AddWithValue("param13", Department);
                cmdUpdateE.Parameters.AddWithValue("param14", EmployeeType);
                cmdUpdateE.Parameters.AddWithValue("param15", MaritalStatus);
                cmdUpdateE.Parameters.AddWithValue("param16", EmployeeStatus);
                cmdUpdateE.Parameters.AddWithValue("idEmployee", IdEmployee);

                //se declara una variable int como respuesta del proceso para saber si se realizó o no
                int valueEUpdate = cmdUpdateE.ExecuteNonQuery();
                //evalúamos la respuesta
                if (valueEUpdate == 1)
                {
                    //si se actualizó el empleado, procedemos a actualizar el usuario
                    //creamos el query
                    string queryUpdateU = "UPDATE tbUserData " +
                                            "SET IdBusinessP = @param17 " +
                                            "WHERE username = @username";
                    //creamos el comando SQL
                    SqlCommand cmdUpdateU = new SqlCommand(queryUpdateU, Command.Connection);
                    //Le agregamos el valor a los parámetros
                   cmdUpdateU.Parameters.AddWithValue("param17", BusinessPosition);
                    cmdUpdateU.Parameters.AddWithValue("username", Username);
                    //Se declara una variable int como respuesta del proceso
                    int valueUserUpdate = cmdUpdateU.ExecuteNonQuery();
                    //retornamos este ultimo valor para saber si se completó todo el proceso.
                    if (valueUserUpdate == 1)
                    {
                        return 1;
                    }
                    else
                    {
                        MessageBox.Show("Los datos del empleado fueron actualizados, pero debido a un error su nombre de usuario y el puesto no pudieron ser actualizados.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return 1;
                    }
                }
                else
                {
                    //si no se pudo actualizar el empleado, se regresa un 0 directamente.
                    return 0;
                }
            }
            catch (SqlException ex)
            {
                //Si surge un error en el try, se devuelve un -1
                MessageBox.Show(ex.Message);
                return -1;
            }
            finally
            {
                Command.Connection.Close();
            }
        }

        public int PasswordRestore()
        {
            try
            {
                //Abrimos conexión con la base
                Command.Connection = getConnection();
                //Creamos el query
                string queryRestorePassword = "UPDATE tbUserData SET password = @param1, temporalpassword = @param2 WHERE username = @param3";
                //creamos comando con el query y la conexión
                SqlCommand cmdRestorePassword = new SqlCommand (queryRestorePassword, Command.Connection);
                //le damos valor a los parámetros
                cmdRestorePassword.Parameters.AddWithValue("param1", Password);
                cmdRestorePassword.Parameters.AddWithValue("param2", true);
                cmdRestorePassword.Parameters.AddWithValue("param3", Username);
                //Creamos variable int para saber el resultado del proceso
                int restoreAnswer = cmdRestorePassword.ExecuteNonQuery();
                if (restoreAnswer == 1)
                {
                    //si la respuesta es 1, entonces la contraseña se restableció correctamente
                    //retornamos 1
                    return 1;
                }
                else
                {
                    //si no se pudo restablecer, se retorna un 0
                    MessageBox.Show("La contraseña no pudo ser restablecida.", "Ocurrió un error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return 0;
                }

            }
            catch (Exception ex)
            {
                //si ocurre un error en el try retornamos un -1
                MessageBox.Show(ex.Message);
                return -1;
                
            }
            finally
            {
                Command.Connection.Close();
            }
        }

        #region OBTENCIÓN DE DATOS PARA LOS DROPDOWNS DEL FORMULARIO
        public DataSet ObtenerEstadosCiviles()
        {
            try
            {
                Command.Connection = getConnection();
                string query = "SELECT*FROM tbmaritalStatus";
                SqlCommand cmd = new SqlCommand(query, Command.Connection);
                cmd.ExecuteNonQuery();

                //El adaptador recibe la info que encontró el "cmd"
                SqlDataAdapter adp = new SqlDataAdapter(cmd);

                //el siguiente dataset va a ser el que el método va a devolver
                DataSet ds = new DataSet();

                //se llena el dataset "ds" con la información que recibió el adaptador "adp"
                adp.Fill(ds, "tbmaritalStatus");

                //se devuelve el dataset
                return ds;

            }
            catch (SqlException ex)
            {
                MessageBox.Show("EC-002: No se puedieron obtener los datos de los Estados Civiles");
                return null;
            }
            finally
            {
                Command.Connection.Close();
            }
        }

        public DataSet ObtenerDepartamentos()
        {
            try
            {
                Command.Connection = getConnection();
                string query = "SELECT*FROM tbDepartment";
                SqlCommand cmd = new SqlCommand(query, Command.Connection);
                cmd.ExecuteNonQuery();

                //El adaptador recibe la info que encontró el "cmd"
                SqlDataAdapter adp = new SqlDataAdapter(cmd);

                //el siguiente dataset va a ser el que el método va a devolver
                DataSet ds = new DataSet();

                //se llena el dataset "ds" con la información que recibió el adaptador "adp"
                adp.Fill(ds, "tbDepartment");

                //se devuelve el dataset
                return ds;

            }
            catch (SqlException ex)
            {
                MessageBox.Show("EC-003: No se puedieron obtener los datos de los Departamentos");
                return null;
            }
            finally
            {
                Command.Connection.Close();
            }
        }

        public DataSet ObtenerTiposEmpleado()
        {
            try
            {
                Command.Connection = getConnection();
                string query = "SELECT*FROM tbTypeE";
                SqlCommand cmd = new SqlCommand(query, Command.Connection);
                cmd.ExecuteNonQuery();

                //El adaptador recibe la info que encontró el "cmd"
                SqlDataAdapter adp = new SqlDataAdapter(cmd);

                //el siguiente dataset va a ser el que el método va a devolver
                DataSet ds = new DataSet();

                //se llena el dataset "ds" con la información que recibió el adaptador "adp"
                adp.Fill(ds, "tbTypeE");

                //se devuelve el dataset
                return ds;

            }
            catch (SqlException ex)
            {
                MessageBox.Show("EC-004: No se puedieron obtener los datos de los Tipos de Empleado");
                return null;
            }
            finally
            {
                Command.Connection.Close();
            }
        }

        public DataSet ObtenerPuestosEmpleado()
        {
            try
            {
                Command.Connection = getConnection();
                string query = "SELECT* FROM tbBusinessP WHERE IdBusinessP = 1 OR IdBusinessP = 2";
                SqlCommand cmd = new SqlCommand(query, Command.Connection);
                cmd.ExecuteNonQuery();

                //El adaptador recibe la info que encontró el "cmd"
                SqlDataAdapter adp = new SqlDataAdapter(cmd);

                //el siguiente dataset va a ser el que el método va a devolver
                DataSet ds = new DataSet();

                //se llena el dataset "ds" con la información que recibió el adaptador "adp"
                adp.Fill(ds, "tbBusinessP");

                //se devuelve el dataset
                return ds;

            }
            catch (SqlException ex)
            {
                MessageBox.Show($"EC-005: No se puedieron obtener los datos de los Puestos de empleado\n\n{ex.Message}");
                return null;
            }
            finally
            {
                Command.Connection.Close();
            }
        }

        public DataSet ObtainBusinessPositionsCEOCase()
        {
            try
            {
                //conexion con la base
                Command.Connection = getConnection();
                //query de la consulta
                string query = "SELECT * FROM tbBusinessP";
                //Comando SQL con query y conexión
                SqlCommand cmd = new SqlCommand(query, Command.Connection);
                //ejecutamos el comando
                cmd.ExecuteNonQuery();

                //El adaptador recibe la info que encontró el "cmd"
                SqlDataAdapter adp = new SqlDataAdapter(cmd);

                //el siguiente dataset va a ser el que el método va a devolver
                DataSet ds = new DataSet();

                //se llena el dataset "ds" con la información que recibió el adaptador "adp"
                adp.Fill(ds, "tbBusinessP");

                //se devuelve el dataset
                return ds;

            }
            catch (SqlException ex)
            {
                MessageBox.Show($"EC-005: No se puedieron obtener los datos de los Puestos de empleado\n\n{ex.Message}");
                return null;
            }
            finally
            {
                Command.Connection.Close();
            }
        }

        public DataSet ObtenerEstadosEmpleado()
        {
            try
            {
                Command.Connection = getConnection();
                string query = "SELECT*FROM tbEmployeeStatus WHERE IdStatus = 1 OR IdStatus = 3 OR IdStatus = 4";
                SqlCommand cmd = new SqlCommand(query, Command.Connection);
                cmd.ExecuteNonQuery();

                //El adaptador recibe la info que encontró el "cmd"
                SqlDataAdapter adp = new SqlDataAdapter(cmd);

                //el siguiente dataset va a ser el que el método va a devolver
                DataSet ds = new DataSet();

                //se llena el dataset "ds" con la información que recibió el adaptador "adp"
                adp.Fill(ds, "tbEmployeeStatus");

                //se devuelve el dataset
                return ds;

            }
            catch (SqlException ex)
            {
                MessageBox.Show("EC-003: No se puedieron obtener los datos de los Estados de Empleado");
                return null;
            }
            finally
            {
                Command.Connection.Close();
            }

        }

        public DataSet ObtainBanks()
        {
            try
            {
                Command.Connection = getConnection();
                string query = "SELECT*FROM tbBanks";
                SqlCommand cmd = new SqlCommand(query, Command.Connection);
                cmd.ExecuteNonQuery();

                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();

                adp.Fill(ds, "tbBanks");
                return ds;
            }
            catch (SqlException ex)
            {
                MessageBox.Show("No se pudieron obtener los datos de los Bancos");
                return null;

            }
            finally
            {
                Command.Connection.Close();
            }
        }
        #endregion
    }
}
