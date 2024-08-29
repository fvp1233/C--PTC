using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PTC2024.Model.DTO.CustomersDTO;

namespace PTC2024.Model.DAO.CustomersDAO
{
 class DAOUpdateCustomers:DTOUpdateCustomers
    {
        readonly SqlCommand command = new SqlCommand();

        //Metodo para actualizar Clientes
        public int updateCustomers()
        {
            try
            {
                command.Connection = getConnection();

                //Se declara la consulta
                string query = "UPDATE tbCustomer SET DUI = @DUI, names = @Names, lastNames = @LastNames, phone = @Phone, email= @Email, address = @Address, idTypeC = @idTypeC WHERE IdCustomer = @Id";

                //Se le asignan los valores a los parametros
                SqlCommand cmd = new SqlCommand(query, command.Connection);
                cmd.Parameters.AddWithValue("@DUI", Dui);
                cmd.Parameters.AddWithValue("@Names", Name);
                cmd.Parameters.AddWithValue("@LastNames",LastNames);
                cmd.Parameters.AddWithValue("@Phone", Phone);
                cmd.Parameters.AddWithValue("@Email", Email);
                cmd.Parameters.AddWithValue("@Address", Address);
                //cmd.Parameters.AddWithValue("@idTypeC", ClientType);
                cmd.Parameters.AddWithValue("@Id", IdClient);
                //La consulta la guardara en la variable respuesta
                int answer = cmd.ExecuteNonQuery();

                if (answer == 1) 
                {
                    return answer;
                }

                else
                {
                    return 0;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return -1;

                
            }

            finally
            {
                command.Connection.Close();
            }
        }
   
    }

    
}
