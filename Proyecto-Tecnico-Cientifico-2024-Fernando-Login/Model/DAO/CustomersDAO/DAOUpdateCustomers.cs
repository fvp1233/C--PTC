using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using PTC2024.Model.DTO.CustomersDTO;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace PTC2024.Model.DAO.CustomersDAO
{
    internal class DAOUpdateCustomers: DTOUpdateCustomers
    {
        readonly SqlCommand Command = new SqlCommand();

        public int UpdateCustomers()
        {
            try
            {
                //Se crea la conexión a la base
                Command.Connection = getConnection();

                //Se crea el query para actualizar al empleado 
                string queryUpdateE = "UPDATE tbCustomer SET " +
                                       "DUI = @param1, " +
                                       "names = @param2, " +
                                       "lastNames = @param3, " +
                                       "phone = @param4, " +
                                       "email = @param5, " +
                                       "address = @param6, " +
                                       "IdtypeC = @param7, ";
                //Se crea el comando Sql que tendrá el query y la conexión
                SqlCommand cmdUpdateC = new SqlCommand(queryUpdateE, Command.Connection);
                //Se le agregan los valores a los parámeros
                cmdUpdateC.Parameters.AddWithValue("param1", Dui);
                cmdUpdateC.Parameters.AddWithValue("param2", Names);
                cmdUpdateC.Parameters.AddWithValue("param3", LastNames);
                cmdUpdateC.Parameters.AddWithValue("param4", Phone);
                cmdUpdateC.Parameters.AddWithValue("param5", Email);
                cmdUpdateC.Parameters.AddWithValue("param6", Address);
                cmdUpdateC.Parameters.AddWithValue("param7", TypeC);

                //se declara una variable int como respuesta del proceso para saber si se realizó o no
                int valueCUpdate = cmdUpdateC.ExecuteNonQuery();
                //evalúamos la respuesta
                if (valueCUpdate == 1)
                {
                    //si se actualizó el empleado, procedemos a actualizar el usuario
                    //creamos el query
                    string queryUpdateC = "UPDATE tbCustomer " +
                                            "SET TypeC = @param7 " +
                                            "WHERE names = @names";
                    //creamos el comando SQL
                    SqlCommand cmdUpdateU = new SqlCommand(queryUpdateC, Command.Connection);
                    //Le agregamos el valor a los parámetros
                    cmdUpdateU.Parameters.AddWithValue("param7", TypeC);
                    cmdUpdateU.Parameters.AddWithValue("names", Names);
                    //Se declara una variable int como respuesta del proceso
                    int valueClientUpdate = cmdUpdateU.ExecuteNonQuery();
                    //retornamos este ultimo valor para saber si se completó todo el proceso.
                    if (valueClientUpdate == 1)
                    {
                        return 1;
                    }
                    else
                    {
                        MessageBox.Show("Los datos del cliente fueron actualizados, pero debido a un error en su nombre de usuario y el puesto tipo de cliente no pudieron ser ingresados.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
        public DataSet ObtenerTiposC()
        {
            try
            {
                Command.Connection = getConnection();
                string query = "SELECT*FROM tbTypeC";
                SqlCommand cmd = new SqlCommand(query, Command.Connection);
                cmd.ExecuteNonQuery();

                //El adaptador recibe la info que encontró el "cmd"
                SqlDataAdapter adp = new SqlDataAdapter(cmd);

                //el siguiente dataset va a ser el que el método va a devolver
                DataSet ds = new DataSet();

                //se llena el dataset "ds" con la información que recibió el adaptador "adp"
                adp.Fill(ds, "tbTypeC");

                //se devuelve el dataset
                return ds;

            }
            catch (SqlException ex)
            {
                MessageBox.Show("EC-002: No se puedieron obtener los datos de los  tipos de empleado");
                return null;
            }
            finally
            {
                Command.Connection.Close();
            }
        }

    }
}
