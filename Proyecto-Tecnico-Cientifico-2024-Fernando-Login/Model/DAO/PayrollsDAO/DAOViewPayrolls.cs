using PTC2024.Model.DTO.PayrollDTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;

namespace PTC2024.Model.DAO.PayrollsDAO
{
    internal class DAOViewPayrolls: DTOViewPayrolls
    {
        readonly SqlCommand comand = new SqlCommand();

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
                string queryPayroll = "INSERT INTO tbPayroll VALUES (@netPay,@income,@issueDate,@securityNumber,@AFP, @ISSS, @bankAccount,@IdEmployee)";
                SqlCommand cmdAddPayroll = new SqlCommand(@queryPayroll, comand.Connection);
                cmdAddPayroll.Parameters.AddWithValue("netPay", NetPay);
                cmdAddPayroll.Parameters.AddWithValue("income", Income);
                cmdAddPayroll.Parameters.AddWithValue("issueDate", IssueDate);
                cmdAddPayroll.Parameters.AddWithValue("securityNumber", SecurityNumber);
                cmdAddPayroll.Parameters.AddWithValue("AFP", Afp);
                cmdAddPayroll.Parameters.AddWithValue("ISSS", Isss);
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
