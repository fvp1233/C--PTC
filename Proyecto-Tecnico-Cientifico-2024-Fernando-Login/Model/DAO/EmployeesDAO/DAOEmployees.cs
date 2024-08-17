﻿using PTC2024.Model.DTO;
using PTC2024.Model.DTO.EmployeesDTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PTC2024.Model.DAO.EmployeesDAO
{
    class DAOEmployees : DTOEmployees
    {
        readonly SqlCommand Command = new SqlCommand();
        
        public DataSet GetEmployees()
        {
            try
            {
                Command.Connection = getConnection();
                string query = "SELECT*FROM viewEmployees WHERE [Estado] = 'Activo' OR [Estado] = 'Maternidad' OR [Estado] = 'Incapacidad'";
                SqlCommand cmd = new SqlCommand(query, Command.Connection);
                cmd.ExecuteNonQuery();
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataSet dsEmployees = new DataSet();
                adp.Fill(dsEmployees, "viewEmployees");
                return dsEmployees;
            }
            catch (Exception)
            {
                MessageBox.Show("No se pudieron obtener los empleados existentes");
                return null;
              
            }
            finally
            {
                Command.Connection.Close();
            }
        }

        public DataSet EmployeeSearch(string valor)
        {
            try
            {
                Command.Connection= getConnection();
                string querySearch = $"SELECT * FROM viewEmployees WHERE [Nombres] LIKE '%{valor}%' OR [Apellidos] LIKE '%{valor}%' OR [DUI] LIKE '%{valor}%'";
                SqlCommand cmdSearch = new SqlCommand(querySearch, Command.Connection);
                cmdSearch.ExecuteNonQuery();

                SqlDataAdapter adpSearch = new SqlDataAdapter(cmdSearch);
                DataSet dsSearch = new DataSet();
                adpSearch.Fill(dsSearch, "viewEmployees");
                return dsSearch;
            }
            catch (Exception)
            {
                return null;
            }
            finally
            {
                Command.Connection.Close();
            }
        }

        public int DisableEmployee()
        { 
            try
            {
                Command.Connection = getConnection();
                string queryDeleteEmployee = "UPDATE tbEmployee SET IdStatus = @param1 WHERE username = @param2";
                SqlCommand cmdDeleteEmployee = new SqlCommand(queryDeleteEmployee, Command.Connection);
                cmdDeleteEmployee.Parameters.AddWithValue("@param1", 2);
                cmdDeleteEmployee.Parameters.AddWithValue("@param2", Username);
                //se obtendrá una respuesta int con el executeNonquery
                int respuestaDisable = cmdDeleteEmployee.ExecuteNonQuery();

                //Se evalúa la respuesta para saber si procederemos a eliminar el usuario asociado al empleado
                if (respuestaDisable == 1)
                {
                    //Si la respuesta es 1, entonces se eliminó correctamente el empleado
                    string queryDisableUser = "UPDATE tbUserData SET userStatus = 'false' WHERE username = @param3"; 
                    SqlCommand cmdDisableUser = new SqlCommand(queryDisableUser, Command.Connection);
                    cmdDisableUser.Parameters.AddWithValue("param3", Username);

                    //Obtendremos una respuesta de este otro proceso para saber si la tarea de Eliminar un empleado junto con su usuario se completó.
                    int respuestaDisableUser = cmdDisableUser.ExecuteNonQuery();
                    //Se devuelve esta respuesta para saber si se completó todo el proceso
                    if (respuestaDisableUser == 1)
                    {
                        return 1;
                    }
                    else
                    {
                        //En caso de que si se deshabilite el empleado pero no su usuario, se ejecuta este método para volver a habilitar el empleado y avisar al usuario que el usuario de dicho empleado no se logró deshabilitar y el proceso no se completó.
                        RollBackDisable();
                        return 0;
                    }
                }
                else
                {
                    //Si el proceso de eliminar empleado no se hizo, se devuelve un cero, para avisar al usuario.
                    return 0;
                }
                
            }
            catch (SqlException ex)
            {
                //Si en caso ocurriera un error, se devuelve un -1
                MessageBox.Show(ex.Message);
                return -1;
                
            }
            finally
            {
                //Se cierra la conexión sin importar el resultado
                Command.Connection.Close();
            }
        }
        public void RollBackDisable()
        {
            string queryEnableEmployee = "UPDATE tbEmployee SET IdStatus = 1 WHERE username = @param4";
            SqlCommand cmdEnableEmployee = new SqlCommand(queryEnableEmployee, Command.Connection);
            cmdEnableEmployee.Parameters.AddWithValue("param4", Username);
            MessageBox.Show("El usuario del empleado no pudo ser deshabilitado", "Proceso incompleto", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        //Método para la filtración por checkbox de tipo de empleado
        public DataSet CheckboxFiltersTypeE(string employeeType)
        {
            try
            {
                //Abrimos conexión con la base
                Command.Connection = getConnection();
                //Creamos el query para la filtración de los checkbox
                string queryCheckboxTypeE = "SELECT * FROM viewEmployees WHERE [Tipo] = @employeeType AND [Estado] = 'Activo'";
                SqlCommand cmdCheckboxTypeE = new SqlCommand(queryCheckboxTypeE, Command.Connection);
                //Le damos valor a los parámetros de la consulta
                cmdCheckboxTypeE.Parameters.AddWithValue("employeeType", employeeType);
                //Ejecutamos el query
                cmdCheckboxTypeE.ExecuteNonQuery();

                //capturamos la respuesta con un adp
                SqlDataAdapter adpCheckBoxTypeE = new SqlDataAdapter(cmdCheckboxTypeE);
                //Creamos un dataset
                DataSet dsCheckBoxTypeE = new DataSet();
                //Llenamos el data set
                adpCheckBoxTypeE.Fill(dsCheckBoxTypeE, "viewEmployees");
                //retornamos el dataset
                return dsCheckBoxTypeE;
            }
            catch (Exception ex)
            {
                //Si ocurre un error en el try, devolvemos un null
                MessageBox.Show(ex.Message);
                return null;
               
            }
            finally 
            {
                Command.Connection.Close(); 
            }
        }

        //Método para la filtración de checkbox de departamento

        public DataSet CheckboxFiltersDepartment(string department)
        {
            try
            {
                //Abrimos conexión con la base
                Command.Connection = getConnection();
                //Creamos el query para la filtración de los checkbox
                string queryCheckboxDepartment = "SELECT * FROM viewEmployees WHERE [Dpto.] = @department AND [Estado] = 'Activo'";
                SqlCommand cmdCheckboxDepartment = new SqlCommand(queryCheckboxDepartment, Command.Connection);
                //Le damos valor a los parámetros de la consulta
                cmdCheckboxDepartment.Parameters.AddWithValue("department", department);
                //Ejecutamos el query
                cmdCheckboxDepartment.ExecuteNonQuery();

                //capturamos la respuesta con un adp
                SqlDataAdapter adpCheckBoxDepartment = new SqlDataAdapter(cmdCheckboxDepartment);
                //Creamos un dataset
                DataSet dsCheckBoxDepartment = new DataSet();
                //Llenamos el data set
                adpCheckBoxDepartment.Fill(dsCheckBoxDepartment, "viewEmployees");
                //retornamos el dataset
                return dsCheckBoxDepartment;
            }
            catch (Exception ex)
            {
                //Si ocurre un error en el try, devolvemos un null
                MessageBox.Show(ex.Message);
                return null;

            }
            finally
            {
                Command.Connection.Close();
            }
        }

        //Método para filtración de datos por checkbox de Estado de empleado
        public DataSet CheckboxFiltersStatus(string status)
        {
            try
            {
                //Abrimos conexión con la base
                Command.Connection = getConnection();
                //Creamos el query para la filtración de los checkbox
                string queryCheckboxStatus = "SELECT * FROM viewEmployees WHERE [Estado] = @department";
                SqlCommand cmdCheckboxStatus = new SqlCommand(queryCheckboxStatus, Command.Connection);
                //Le damos valor a los parámetros de la consulta
                cmdCheckboxStatus.Parameters.AddWithValue("department", status);
                //Ejecutamos el query
                cmdCheckboxStatus.ExecuteNonQuery();

                //capturamos la respuesta con un adp
                SqlDataAdapter adpCheckBoxStatus = new SqlDataAdapter(cmdCheckboxStatus);
                //Creamos un dataset
                DataSet dsCheckBoxStatus = new DataSet();
                //Llenamos el data set
                adpCheckBoxStatus.Fill(dsCheckBoxStatus, "viewEmployees");
                //retornamos el dataset
                return dsCheckBoxStatus;
            }
            catch (Exception ex)
            {
                //Si ocurre un error en el try, devolvemos un null
                MessageBox.Show(ex.Message);
                return null;

            }
            finally
            {
                Command.Connection.Close();
            }
        }
    }
}
