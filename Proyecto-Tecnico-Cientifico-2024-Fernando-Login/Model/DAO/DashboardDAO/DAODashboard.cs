using PTC2024.Model.DTO.DashboardDTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static TheArtOfDev.HtmlRenderer.Adapters.RGraphicsPath;

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

        public decimal GetTotalIncome()
        {
            try
            {
                Command.Connection = getConnection();
                string query = "SELECT SUM(totalPay) FROM tbBills WHERE IdStatusBill != 3 AND dateissuance BETWEEN @fromDate AND @toDate";
                SqlCommand cmd = new SqlCommand(query, Command.Connection);
                cmd.Parameters.AddWithValue("@fromDate", FromDate);
                cmd.Parameters.AddWithValue("@toDate", ToDate);

                object result = cmd.ExecuteScalar();

                if (result == DBNull.Value)
                {
                    TotalPay = 0; // No hay facturas en el rango de fechas
                }
                else
                {
                    TotalPay = Convert.ToDecimal(result);
                }

                return TotalPay;
            }
            catch (Exception ex)
            {
                MessageBox.Show("EC-107: No se pudo obtener los datos de las facturas", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                PayrollsList = new List<PayrollsByDate>();
                string query = @"
            SELECT 
                YEAR(issueDate) AS Year, 
                MONTH(issueDate) AS Month, 
                SUM(netPay + christmasBonus) AS TotalAmount 
            FROM tbPayroll 
            WHERE issueDate BETWEEN @fromDate AND @toDate 
            GROUP BY YEAR(issueDate), MONTH(issueDate)
            ORDER BY Year, Month";
                SqlCommand cmd = new SqlCommand(query, Command.Connection);
                cmd.Parameters.AddWithValue("@fromDate", FromDate);
                cmd.Parameters.AddWithValue("@toDate", ToDate);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    int year = reader.GetInt32(0);
                    int month = reader.GetInt32(1);
                    decimal totalAmount = reader.GetDecimal(2);
                    string dateFormatted = new DateTime(year, month, 1).ToString("MMM yyyy");

                    PayrollsList.Add(new PayrollsByDate
                    {
                        Date = dateFormatted,
                        TotalAmount = totalAmount
                    });

                    NetPay += totalAmount;
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("EC-019: No se pudo obtener el número de planillas", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Command.Connection.Close();
            }
        }
        public void GetSecondAnalisys()
        {
            try
            {
                Command.Connection = getConnection();
                IncomeList = new List<IncomesByDate>();
                string query = @"		SELECT 
              YEAR(dateissuance) AS Year, 
              MONTH(dateissuance) AS Month, 
              SUM(totalPay) AS TotalIncome 
          FROM tbBills 
          WHERE IdStatusBill != 3 AND dateissuance BETWEEN @fromDate AND @toDate 
          GROUP BY YEAR(dateissuance), MONTH(dateissuance)
          ORDER BY Year, Month";
                SqlCommand cmd = new SqlCommand(query, Command.Connection);
                cmd.Parameters.AddWithValue("@fromDate", FromDate);
                cmd.Parameters.AddWithValue("@toDate", ToDate);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    int year = reader.GetInt32(0);
                    int month = reader.GetInt32(1);
                    decimal totalIncome = reader.GetDecimal(2);
                    string dateFormatted = new DateTime(year, month, 1).ToString("MMM yyyy");
                    IncomeList.Add(new IncomesByDate
                    {
                        DateIn = dateFormatted,
                        TotalIncome = totalIncome
                    });
                    TotalPay += totalIncome;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("EC-019: No se pudo obtener el número de planillas", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Command.Connection.Close();
            }
        }
        public void GetTopServices()
        {
            try
            {
                TopServices = new List<KeyValuePair<string, int>>(); // Initialize the list
                Command.Connection = getConnection();
                SqlDataReader reader;
                string query = @"
                SELECT TOP 5 S.serviceName, COUNT(B.idServices) AS ServiceCount
                FROM tbBills B
                INNER JOIN tbServices S ON B.idServices = S.idServices
                WHERE B.dateissuance BETWEEN @fromDate AND @toDate
                GROUP BY S.serviceName
                ORDER BY ServiceCount DESC";
                SqlCommand cmd = new SqlCommand(query, Command.Connection);
                cmd.Parameters.Add("@fromDate", System.Data.SqlDbType.DateTime).Value = FromDate;
                cmd.Parameters.Add("@toDate", System.Data.SqlDbType.DateTime).Value = ToDate;
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    TopServices.Add(
                        new KeyValuePair<string, int>(reader["serviceName"].ToString(), (int)reader["ServiceCount"]));
                }
                reader.Close();

            }
            catch (Exception EX)
            {
                MessageBox.Show($"{EX}EC-019: No se pudo obtener el numero de planillas", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            finally
            {
                Command.Connection.Close();
            }
        }

        public bool LoadData(DateTime startDate, DateTime endDate)
        {
            try
            {
                endDate = new DateTime(endDate.Year, endDate.Month, endDate.Day, endDate.Hour, endDate.Minute, 59);
                if (startDate != this.FromDate || endDate != this.ToDate)
                {
                    this.FromDate = startDate;
                    this.ToDate = endDate;
                    this.NumberDays = (endDate - startDate).Days;
                    GetAnalisys();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {

                return false;
            }
        }

    }
}
