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
    internal class DAOCustomers : DTOCustomers
    {
        readonly SqlCommand Command = new SqlCommand();

        public DataSet getCustomers() 
        {
            try
            {
            Command.Connection = getConnection();
                string query = "SELECT*FROM viewCustomers WHERE [Tipo] = 'Natural' OR [Tipo] = 'Jurídico'";
                SqlCommand cmd = new SqlCommand(query, Command.Connection);
                cmd.ExecuteNonQuery();
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataSet dsCustomers = new DataSet();
                adp.Fill(dsCustomers, "viewCustomers");
                return dsCustomers;
            }
            catch (Exception)
            {
                MessageBox.Show("No se pudieron obtener los clientes existentes");
                return null;

            }
            finally
            {
                Command.Connection.Close();
            }
        }
        public DataSet searchCustomers(string valor)
        {
            try
            {
                Command.Connection = getConnection();
                string querySearch = $"SELECT * FROM viewCustomers WHERE [Cliente] LIKE '%{valor}%' OR [DUI] LIKE '%{valor}%'";
                SqlCommand cmdSearch = new SqlCommand(querySearch, Command.Connection);
                cmdSearch.ExecuteNonQuery();

                SqlDataAdapter adpSearch = new SqlDataAdapter(cmdSearch);
                DataSet dsSearch = new DataSet();
                adpSearch.Fill(dsSearch, "viewCustomers");
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
          
        public int DisableCustomers()
        {
            try
            {
                Command.Connection = getConnection();
                string queryDeleteCustomer = "UPDATE tbCustomer SET IdCustomer = @param1 WHERE names = @param2";
                SqlCommand cmdDeleteCustomer = new SqlCommand(queryDeleteCustomer, Command.Connection);
                cmdDeleteCustomer.Parameters.AddWithValue("@param1", 2);
                cmdDeleteCustomer.Parameters.AddWithValue("@param2", Names);
                int respuestaDisable = cmdDeleteCustomer.ExecuteNonQuery();

                if (respuestaDisable == 1)
                {

                    string queryDisableClient = "UPDATE tbCustomer SET IdCustomer = 'false' WHERE names = @param3";
                    SqlCommand cmdDisableCustomer = new SqlCommand(@queryDisableClient, Command.Connection);
                    cmdDisableCustomer.Parameters.AddWithValue("@param3", Names);

                    int respuestaDisableCustomer = cmdDisableCustomer.ExecuteNonQuery();

                    if (respuestaDisableCustomer == 1)
                    {
                        return 1;
                    }
                    else
                    {
                        RollBackDisable();
                        return 0;
                    }
           
                   
                }
                else
                {
                    return 0;
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
                return -1;
            }
            finally
            {
                Command.Connection.Close();
            }
        }

        public void RollBackDisable()
        {
            string queryEnableCustomers = "UPDATE tbCustomer SET IdCustomer = 1 WHERE names = @param4";
            SqlCommand cmdEnableCustomers = new SqlCommand(queryEnableCustomers, Command.Connection);
            cmdEnableCustomers.Parameters.AddWithValue("@param4", Names);
            MessageBox.Show("El Cliente  no pudo ser deshabilitado", "Proceso incompleto", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
}
    }

