using PTC2024.Model.DTO;
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
    internal class DAOEmployees : DTOAddEmployee
    {
        readonly SqlCommand Command = new SqlCommand();
        
        public DataSet GetEmployees()
        {
          
            try
            {
                Command.Connection = getConnection();
                string query = "SELECT*FROM viewEmployees WHERE Estado = @param1";
                SqlCommand cmd = new SqlCommand(query, Command.Connection);
                cmd.Parameters.AddWithValue("param1", "Activo");
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

        public int DeleteEmployee()
        { 
            try
            {
                Command.Connection = getConnection();
                string queryDeleteEmployee = "UPDATE tbEmployee" +
                                                "SET IdStatus = 2" +
                                                "WHERE username = @param1";
                SqlCommand cmdDeleteEmployee = new SqlCommand(queryDeleteEmployee, Command.Connection);
                cmdDeleteEmployee.Parameters.AddWithValue("param1", Username);
                //se obtendrá una respuesta int con el executeNonquery
                int respuestaDisable = cmdDeleteEmployee.ExecuteNonQuery();
                
                //Se evalúa la respuesta para saber si procederemos a eliminar el usuario asociado al empleado
                if (respuestaDisable == 1)
                {
                    //Si la respuesta es 1, entonces se eliminó correctamente el empleado
                    string queryDeleteUser = "DELETE FROM tbUserData WHERE username = @param2";
                    SqlCommand cmdDeleteUser = new SqlCommand(queryDeleteUser, Command.Connection);
                    cmdDeleteUser.Parameters.AddWithValue("param2", Username);

                    //Obtendremos una respuesta de este otro proceso para saber si la tarea de Eliminar un empleado junto con su usuario se completó.
                    int respuestaDeleteUser = cmdDeleteUser.ExecuteNonQuery();
                    //Se devuelve esta respuesta para saber si se completó todo el proceso
                    return respuestaDeleteUser;
                }
                else
                {
                    //Si el proceso de eliminar empleado no se hizo, se devuelve un cero, para avisar al usuario.
                    return 0;
                }
            }
            catch (Exception)
            {
                //Si en caso ocurriera un error, se devuelve un -1
                return -1;
            }
            finally
            {
                //Se cierra la conexión sin importar el resultado
                Command.Connection.Close();
            }
        }

        public DataSet SearchEmployee(string valor)
        {
            try
            {
                Command.Connection = getConnection();
                string querySearch = $"SELECT * FROM viewEmployees WHERE [Empleado] LIKE '%{valor}%' OR [DUI] LIKE '%{valor}%' OR [Estado] LIKE '%{valor}%'";
                SqlCommand cmdSearch = new SqlCommand (querySearch, Command.Connection);
                SqlDataAdapter adpSearch = new SqlDataAdapter(cmdSearch);
                cmdSearch.ExecuteNonQuery();
                DataSet dsSearch = new DataSet();
                adpSearch.Fill(dsSearch, "viewEmployees");
                return dsSearch;
            }
            catch (SqlException ex)
            {
                //si ocurre un error en el try se devuelve un null
                return null;
            }
            finally
            {
                Command.Connection.Close();
            }
        }
    }
}
