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

        //Obtencion de datos para dropdown de tipo de cliente
        public DataSet ObtenerTiposEmpleado()
        {
            try
            {
                command.Connection = getConnection();
                string query = "SELECT*FROM tbTypeC";
                SqlCommand cmd = new SqlCommand(query, command.Connection);
                cmd.ExecuteNonQuery();


                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                adp.Fill(ds, "tbTypeC");


                return ds;

            }
            catch (SqlException ex)
            {
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
            {//Consulto si el usuario existe
                command.Connection = getConnection();
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
                string queryInsertCustomer = "INSERT INTO tbCustomer (DUI,names,lastNames,phone,email, address, IdtypeC) VALUES (@DUI,@names,@lastNames,@phone,@email,@address, @IdTypeC)";

                SqlCommand cmdInsertCustomer = new SqlCommand(queryInsertCustomer, command.Connection);
                cmdInsertCustomer.Parameters.AddWithValue("@DUI", DUI1);
                cmdInsertCustomer.Parameters.AddWithValue("@names", Names);
                cmdInsertCustomer.Parameters.AddWithValue("@lastNames", Lastnames);
                cmdInsertCustomer.Parameters.AddWithValue("@phone", Phone);
                cmdInsertCustomer.Parameters.AddWithValue("@email", Email);
                cmdInsertCustomer.Parameters.AddWithValue("@address", Address);
                cmdInsertCustomer.Parameters.AddWithValue("@IdTypeC", EmployeeType);

                int respuesta = cmdInsertCustomer.ExecuteNonQuery();

                if (respuesta == 1)
                {


                    return respuesta;

                }
                else
                {
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

        private void Rollback()
        {
            string queryDeleteCustomer = "DELETE FROM tbCustomer WHERE IdTypeC = @IdTypeC";
            SqlCommand cmdDeleteCustomer = new SqlCommand(queryDeleteCustomer, command.Connection);
            cmdDeleteCustomer.Parameters.AddWithValue("IdTypeC", IdCustomer);
        }

        


    }
    
     
}


