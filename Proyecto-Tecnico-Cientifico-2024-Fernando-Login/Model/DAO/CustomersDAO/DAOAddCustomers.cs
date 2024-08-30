using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PTC2024.Model.DTO.CustomersDTO;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using Microsoft.VisualBasic.ApplicationServices;
using System.Net;

namespace PTC2024.Model.DAO.CustomersDAO
{
    class DAOAddCustomers : DTOAddCustomers
    {
        readonly SqlCommand command = new SqlCommand();

        //Metodo para la Obtencion de datos para dropdown de tipo de cliente
        public DataSet getTypeCustomers()
        {
            try
            {
                command.Connection = getConnection();
                //Se realiza la consulta
                string query = "SELECT*FROM tbTypeC";
                SqlCommand cmd = new SqlCommand(query, command.Connection);
                //Devuelve las filas afectadas
                cmd.ExecuteNonQuery();


                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                //Se llena el data set con el tipo de cliente (Natural, Juridico)
                adp.Fill(ds, "tbTypeC");

                //Retorna el dataset
                return ds;
            }
            catch (SqlException ex)
            {
                //En caso no se pudieron obtener los datos retornara un valor nulo y no se pudieron obtener los tipos de clientes
                MessageBox.Show("EC-004: No se puedieron obtener los datos de los Tipos de Cliente");
                return null;
            }
            finally
            {
                command.Connection.Close();
            }
        }
        public int RegisterCustomer()
        {
            try
            {//Consulta si el cliente existe
                command.Connection = getConnection();
                //Define la consulta para seleccionar a traves del DUI
                string queryUserExist = "select DUI from dbo.tbCustomer where DUI=@DUI";
                SqlCommand cmdUserExist = new SqlCommand(queryUserExist, command.Connection);
                cmdUserExist.Parameters.AddWithValue("DUI", DUI1);
                DataTable dt = new DataTable();
                SqlDataAdapter adapter = new SqlDataAdapter(cmdUserExist);
                adapter.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    MessageBox.Show("Cliente ingresado ya Existente");
                    return 1;
                }


                command.Connection = getConnection();
                //Define la consulta con todos sus parametros
                string queryInsertCustomer = "INSERT INTO tbCustomer (DUI,names,lastNames,phone,email, address, IdtypeC) VALUES (@DUI,@names,@lastNames,@phone,@email,@address, @IdTypeC)";

                //Se le asignan los valores a los parametros
                SqlCommand cmdInsertCustomer = new SqlCommand(queryInsertCustomer, command.Connection);
                cmdInsertCustomer.Parameters.AddWithValue("@DUI", DUI1);
                cmdInsertCustomer.Parameters.AddWithValue("@names", Names);
                cmdInsertCustomer.Parameters.AddWithValue("@lastNames", Lastnames);
                cmdInsertCustomer.Parameters.AddWithValue("@phone", Phone);
                cmdInsertCustomer.Parameters.AddWithValue("@email", Email);
                cmdInsertCustomer.Parameters.AddWithValue("@address", Address);
                cmdInsertCustomer.Parameters.AddWithValue("@IdTypeC", ClientType);

                //Se ejecuta la consulta y se guarda en la variable respuesta
                int answer = cmdInsertCustomer.ExecuteNonQuery();

                if (answer == 1)
                {
                    //Retorna el valor de la variable respuesta
                    return answer;
                }
                else
                {//Rollback para eliminar el cliente que se esta llenando
                    Rollback();
                    return 0;
                }
            }
            catch (Exception ex)
            {
                Rollback();
                return -1;
            }
            finally
            {
                command.Connection.Close();
            }
        }

        //Metodo Rollback sirve para eliminar la informacion del cliente al no poder ser ingreado el cliente
        private void Rollback()
        {
            string queryDeleteCustomer = "DELETE FROM tbCustomer WHERE IdTypeC = @IdTypeC";
            SqlCommand cmdDeleteCustomer = new SqlCommand(queryDeleteCustomer, command.Connection);
            cmdDeleteCustomer.Parameters.AddWithValue("IdTypeC", IdCustomer);
        }
    }


}


