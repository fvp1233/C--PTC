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
    internal class DAOEmployees : dbContext
    {
        readonly SqlCommand Command = new SqlCommand();
        
        public DataSet GetEmployees()
        {
            try
            {
                Command.Connection = getConnection();
                string query = "SELECT*FROM  viewEmployees";
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
    }
}
