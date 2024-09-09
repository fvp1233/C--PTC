using PTC2024.Model.DTO.DashboardDTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PTC2024.Model.DAO.DashboardDAO
{
    internal class DAODashboard : DTODashboard
    {
        readonly SqlCommand Command = new SqlCommand();
        public int GetNumberEmployee()
        {
            try
            {
                Command.Connection = getConnection();
                string query = "SELECT COUNT(IdEmployee) FROM tbEmployee WHERE IdStatus != 2";
                SqlCommand cmd = new SqlCommand(query, Command.Connection);
                NumberEmployee = (int)cmd.ExecuteScalar();
                return NumberEmployee;
            }
            catch (Exception ex)
            {
                MessageBox.Show("EC-015: No se pudo obtener el numero de empleados", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }
            finally
            {
                Command.Connection.Close();
            }
        }
        public int GetNumberServices()
        {
            try
            {
                Command.Connection = getConnection();
                string query = "SELECT COUNT(IdServices) FROM tbServices";
                SqlCommand cmd = new SqlCommand(query, Command.Connection);
                NumberServices = (int)cmd.ExecuteScalar();
                return NumberServices;
            }
            catch (Exception ex)
            {
                MessageBox.Show("EC-016: No se pudo obtener el numero de servicios", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }
            finally
            {
                Command.Connection.Close();
            }
        }
        public int GetNumberCustomer()
        {
            try
            {
                Command.Connection = getConnection();
                string query = "SELECT COUNT(IdCustomer) FROM tbCustomer";
                SqlCommand cmd = new SqlCommand(query, Command.Connection);
                NumberCostumers = (int)cmd.ExecuteScalar();
                return NumberCostumers;
            }
            catch (Exception ex)
            {
                MessageBox.Show("EC-017: No se pudo obtener el numero de clientes", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }
            finally
            {
                Command.Connection.Close();
            }
        }
        public int GetNumberBills()
        {
            try
            {
                Command.Connection = getConnection();
                string query = "SELECT COUNT(IdBill) FROM tbBills";
                SqlCommand cmd = new SqlCommand(query, Command.Connection);
                NumberBills = (int)cmd.ExecuteScalar();
                return NumberBills;
            }
            catch (Exception ex)
            {
                MessageBox.Show("EC-018: No se pudo obtener el numero de facturas", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }
            finally
            {
                Command.Connection.Close();
            }
        }
        public void GetAnalisys()
        {
            try
            {
                Command.Connection = getConnection();
                //string queryFisrt = "SELECT MIN(issueDate) FROM tbPayroll";
                //SqlCommand cmdFirst =  new SqlCommand(queryFisrt, Command.Connection);
                //DateTime firstIssueD = (DateTime)cmdFirst.ExecuteScalar();
                //FromDate = firstIssueD < FromDate ? firstIssueD : FromDate;
                FromDate = new DateTime(2020, 8, 1);
                ToDate = new DateTime(2025, 7, 7);
                PayrollsList = new List<PayrollsByDate>();
                string query = "SELECT issueDate,SUM(netPay + christmasBonus) FROM tbPayroll WHERE issueDate BETWEEN @fromDate AND @toDate group by issueDate";
                SqlCommand cmd = new SqlCommand(query, Command.Connection);
                //cmd.Parameters.Add("@fromDate", System.Data.SqlDbType.DateTime).Value = FromDate;
                //cmd.Parameters.Add("@toDate", System.Data.SqlDbType.DateTime).Value = ToDate;
                cmd.Parameters.AddWithValue("@fromDate", FromDate);
                cmd.Parameters.AddWithValue("@toDate", ToDate);
                SqlDataReader reader = cmd.ExecuteReader();
                var resultTable = new List<KeyValuePair<DateTime, decimal>>();
                while (reader.Read())
                {
                    resultTable.Add(new KeyValuePair<DateTime, decimal>((DateTime)reader[0], (decimal)reader[1]));
                    NetPay += (decimal)reader[1];
                }
                reader.Close();
                foreach (var item in resultTable)
                {
                    PayrollsList.Add(new PayrollsByDate()
                    {
                        Date = item.Key.ToString("dd MMM"),
                        TotalAmount = item.Value
                    });
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("EC-019: No se pudo obtener el numero de planillas", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            finally
            {
                Command.Connection.Close();
            }
        }

    }
}
