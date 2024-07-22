using PTC2024.Model.DTO.PayrollDTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using PTC2024.View.Empleados;

namespace PTC2024.Model.DAO.PayrollsDAO
{
    internal class DAOAddPayroll : DTOAddPayroll
    {
        readonly SqlCommand command = new SqlCommand();

        public DataSet GetEmployeeName()
        {
            try
            {
                command.Connection = getConnection();
                string query = "SELECT CONCAT (Id_Employee,'.',names,' ',lastName) AS fullEmployeeInfo FROM tbEmployee";
                SqlCommand cmd = new SqlCommand(query, command.Connection);
                cmd.ExecuteNonQuery();

                SqlDataAdapter adp = new SqlDataAdapter(cmd);

                DataSet ds = new DataSet();

                adp.Fill(ds, "tbEmployee");
                return ds;
            }
            catch (SqlException ex)
            {
                MessageBox.Show("EC-002: No se pudieron obtener los datos de el empleado");
                return null;
            }
            finally
            {
                command.Connection.Close();
            }
        }
    }
}
