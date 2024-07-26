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
using System.Windows.Input;

namespace PTC2024.Model.DAO.PayrollsDAO
{
    internal class DAOAddPayroll : DTOAddPayroll
    {
        readonly SqlCommand comand = new SqlCommand();

        public DataSet GetEmployeeName()
        {
            try
            {
                comand.Connection = getConnection();
                string query = "SELECT CONCAT (Id_Employee,'. ',names,' ',lastName) AS fullEmployeeInfo FROM tbEmployee";
                SqlCommand cmd = new SqlCommand(query, comand.Connection);
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
                comand.Connection.Close();
            }
        }
        public DataSet GetEmployee()
        {
            try
            {
                comand.Connection = getConnection();
                string queryEmployee = "SELECT * FROM tbEmployee";
                SqlCommand cmdEmployeeInfo = new SqlCommand(@queryEmployee, comand.Connection);
                cmdEmployeeInfo.ExecuteNonQuery();
                SqlDataAdapter adp = new SqlDataAdapter(cmdEmployeeInfo);
                DataSet ds = new DataSet();
                adp.Fill(ds, "tbEmployee");
                return ds;
            }
            catch (Exception)
            {
                return null;
            }
            finally
            {
                getConnection().Close();
            }
            
        }
        public int AddPayroll()
        {
            try
            {
                GetEmployee();
                comand.Connection = getConnection();
                string queryPayroll = "INSERT INTO tbPayroll VALUES (@gross_Pay,@net_Pay,@income,@bonus,@month,@security_Number, @AFP, @ISS, @bank_Account,@Id_Employee)";
                SqlCommand cmdAddPayroll = new SqlCommand(@queryPayroll, comand.Connection);
                cmdAddPayroll.Parameters.AddWithValue("gross_Pay", GrossPay);
                cmdAddPayroll.Parameters.AddWithValue("net_Pay", NetPay);
                cmdAddPayroll.Parameters.AddWithValue("income", Income);
                cmdAddPayroll.Parameters.AddWithValue("bonus", Bonus);
                cmdAddPayroll.Parameters.AddWithValue("month", IssueDate);
                cmdAddPayroll.Parameters.AddWithValue("security_Number", SecurityNumber);
                cmdAddPayroll.Parameters.AddWithValue("AFP", Afp);
                cmdAddPayroll.Parameters.AddWithValue("ISS", Iss);
                cmdAddPayroll.Parameters.AddWithValue("bank_Account", BanckAccount);
                cmdAddPayroll.Parameters.AddWithValue("Id_Employee", IdPayroll);

                int answer = cmdAddPayroll.ExecuteNonQuery();
                if (answer == 1)
                {
                    return 1;
                }
                else { return 0; }
            }
            catch (SqlException ex)
            {
                MessageBox.Show($"EC-009: {ex.Message}", "Error Critico", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }
            finally
            {
                comand.Connection.Close();
            }
        }
    }
}
