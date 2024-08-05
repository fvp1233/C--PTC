using PTC2024.Model.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PTC2024.Model.DAO
{
    internal class DAOAddEmployee : DTOAddEmployee
    {
        readonly SqlCommand command = new SqlCommand();

        #region OBTENCIÓN DE DATOS PARA LOS DROPDOWNS DEL FORMULARIO
        public DataSet ObtenerEstadosCiviles()
        {
            try
            {
                command.Connection = getConnection();
                string query = "SELECT*FROM tbmaritalStatus";
                SqlCommand cmd = new SqlCommand(query, command.Connection);
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
                command.Connection.Close();
            }
        }

        public DataSet ObtenerDepartamentos()
        {
            try
            {
                command.Connection = getConnection();
                string query = "SELECT*FROM tbDepartment";
                SqlCommand cmd = new SqlCommand(query, command.Connection);
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
                command.Connection.Close();
            }
        }

        public DataSet ObtenerTiposEmpleado()
        {
            try
            {
                command.Connection = getConnection();
                string query = "SELECT*FROM tbTypeE";
                SqlCommand cmd = new SqlCommand(query, command.Connection);
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
                command.Connection.Close();
            }
        }

        public DataSet ObtenerPuestosEmpleado()
        {
            try
            {
                command.Connection = getConnection();
                string query = "SELECT*FROM tbBusinessP";
                SqlCommand cmd = new SqlCommand(query, command.Connection);
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
                MessageBox.Show("EC-005: No se puedieron obtener los datos de los Puestos de empleado");
                return null;
            }
            finally
            {
                command.Connection.Close();
            }
        }

        public DataSet ObtenerEstadosEmpleado()
        {
            try
            {
                command.Connection = getConnection();
                string query = "SELECT*FROM tbEmployeeStatus";
                SqlCommand cmd = new SqlCommand(query, command.Connection);
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
                command.Connection.Close();
            }
            
        }

        public DataSet ObtainBanks()
        {
            try
            {
                command.Connection = getConnection();
                string query = "SELECT*FROM tbBanks";
                SqlCommand cmd = new SqlCommand(query, command.Connection);
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
                command.Connection.Close();
            }
        }
        #endregion

        public int RegisterEmployee()
        {
            try
            {
                //Conexión con la base de datos
                command.Connection = getConnection();
                //Se crea el query con la sentencia SQL para insertar los datos en la base para la tabla "tbUserData"
                string queryInsertUser = "INSERT INTO tbUserData(username, password, IdBusinessP, userStatus) VALUES (@username, @password, @IdBusinessP, @userStatus)";
                //Se crea el comando SQL que contendrá la conexión a la base y el query
                SqlCommand cmdInsertUser = new SqlCommand(queryInsertUser, command.Connection);
                //Se le asignan los valores a los parámetros del query con los atributos provenientes del DTO
                cmdInsertUser.Parameters.AddWithValue("username", Username);
                cmdInsertUser.Parameters.AddWithValue("password", Password);
                cmdInsertUser.Parameters.AddWithValue("IdBusinessP", BusinessPosition);
                cmdInsertUser.Parameters.AddWithValue("userStatus", UserSatus);
                //Se ejecuta el query con los valores asignados a cada parámetro
                //Para devolver una respuesta usamos el ExecuteNonQuery
                int respuesta = cmdInsertUser.ExecuteNonQuery();

                //Ahora evaluamos el valor de la variable "respuesta" para continuar o terminar el proceso.
                if (respuesta == 1)
                {
                    //Si el valor de la respuesta es 1, entonces el usuario se ingresó correctamente, por lo que procedemos a hacer la inserción del empleado de dicho usuario.
                    string queryInsertEmployee = "INSERT INTO tbEmployee(names, lastName, DUI, birthDate, email, phone, address, salary, bankAccount, affiliationNumber, hireDate, IdBank, IdDepartment, IdTypeE, IdMaritalS, IdStatus, username) VALUES (@param1, @param2, @param3, @param4, @param5, @param6, @param7, @param8, @param9, @param10, @param11, @param12, @param13, @param14, @param15, @param16, @param17)";
                    //Se crea el comando SQL con la conexión y el query
                    SqlCommand cmdInsertEmployee = new SqlCommand(@queryInsertEmployee, command.Connection);
                    //Se asigna un valor a cada parámetro con los atributos del DTO
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
                    //se ejecuta el comando ya con todos los valores de los parámetros
                    respuesta = cmdInsertEmployee.ExecuteNonQuery();
                    //Si el valor del executeNonQuery es 1, los valores fueron ingresados
                    if (respuesta == 1)
                    {
                        return 1;
                    }
                    else
                    {
                        //si la respuesta no es 1, entonces el empleado no se agregó, por lo que tenemos que eliminar el usuario que se había creado para dicho empleado. Esto se hace en el método RollBack
                        RollBack();
                        return 0;
                    }
                }
                else
                {
                    //si el usuario no se ingresó, se regresa un 0
                    return 0;
                }
            }
            catch (Exception ex)
            {
                RollBack();
                return -1;
                //se retorna -1 en caso de que haya ocurrido un error en el try
            }           
            finally
            {
                command.Connection.Close();
            }
            
        }

        public void RollBack()
        {
            string queryDeleteUser = "DELETE FROM tbUserData WHERE username = @username";
            SqlCommand cmdDeleteUser = new SqlCommand(queryDeleteUser, command.Connection);
            cmdDeleteUser.Parameters.AddWithValue("username", Username);
        }

        public int ValidateFirstUse()
        {
            //Este método revisará en la base si ya existe algún empleado que pueda iniciar sesión
            try
            {
                command.Connection = getConnection();
                //creamos query con las acciones a realizar
                string queryValidateE = "SELECT COUNT(*) FROM viewLogIn";
                SqlCommand cmdValidateE = new SqlCommand( queryValidateE, command.Connection);
                int totalUsers = (int)cmdValidateE.ExecuteScalar();
                return totalUsers;
            }
            catch (SqlException sqlEx)
            {
                //Si sucede un error en el try se devuelve un -1
                MessageBox.Show(sqlEx.Message);
                return -1;
                
            }
            catch (Exception ex)
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
