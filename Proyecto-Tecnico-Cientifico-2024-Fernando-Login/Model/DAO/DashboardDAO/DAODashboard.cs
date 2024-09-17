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
        //public double GetTotalIncome()
        //{
        //    try
        //    {
        //        Command.Connection = getConnection();
        //        string query = "SELECT SUM(totalPay) FROM tbBills WHERE IdStatusBill != 3";
        //        SqlCommand cmd = new SqlCommand(query, Command.Connection);
        //        TotalPay = (double)cmd.ExecuteScalar();
        //        return TotalPay;
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show($"{ex}EC-015: No se pudo obtener el numero de empleados", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        return -1;
        //    }
        //    finally
        //    {
        //        Command.Connection.Close();
        //    }
        //}
        public double GetTotalIncome()
        {
            try
            {
                Command.Connection = getConnection();

                // Asegúrate de que la conexión esté abierta
                if (Command.Connection.State != System.Data.ConnectionState.Open)
                {
                    Command.Connection.Open();
                }

                string query = "SELECT SUM(totalPay) FROM tbBills WHERE IdStatusBill != 3";
                SqlCommand cmd = new SqlCommand(query, Command.Connection);

                double result = Convert.ToDouble(cmd.ExecuteScalar());

                TotalPay = result;

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
                //FromDate = new DateTime(2020, 8, 1);
                //ToDate = new DateTime(2025, 7, 7);
                PayrollsList = new List<PayrollsByDate>();
                string query = "SELECT issueDate,SUM(netPay + christmasBonus) FROM tbPayroll WHERE issueDate BETWEEN @fromDate AND @toDate group by issueDate";
                SqlCommand cmd = new SqlCommand(query, Command.Connection);
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
                if (NumberDays <= 30)
                {
                    PayrollsList = (from orderlist in resultTable
                                    group orderlist by orderlist.Key.ToString("dd MMM") into order
                                    select new PayrollsByDate
                                    {
                                        Date = order.Key,
                                        TotalAmount = order.Sum(amount => amount.Value)

                                    }).ToList();
                }
                else if (NumberDays <= 92)
                {
                    PayrollsList = (from orderList in resultTable
                                    group orderList by CultureInfo.CurrentCulture.Calendar.GetWeekOfYear(orderList.Key, CalendarWeekRule.FirstDay, DayOfWeek.Monday)
                                    into order
                                    select new PayrollsByDate
                                    {
                                        Date = "Week " + order.Key.ToString(),
                                        TotalAmount = order.Sum(amount => amount.Value)
                                    }).ToList();
                }
                else if (NumberDays <= (365 * 2))
                {
                    bool isYear = NumberDays <= 365 ? true : false;
                    PayrollsList = (from orderList in resultTable
                                    group orderList by orderList.Key.ToString("MMM yyyy") into order
                                    select new PayrollsByDate
                                    {
                                        Date = isYear ? order.Key.Substring(0, order.Key.IndexOf(" ")) : order.Key,
                                        TotalAmount = order.Sum(amount => amount.Value)
                                    }).ToList();
                }
                else
                {
                    PayrollsList = (from orderList in resultTable
                                    group orderList by orderList.Key.ToString("yyyyy") into order
                                    select new PayrollsByDate
                                    {
                                        Date = order.Key,
                                        TotalAmount = order.Sum(amount => amount.Value)
                                    }).ToList();
                }
                //foreach (var item in resultTable)
                //{
                //    PayrollsList.Add(new PayrollsByDate()
                //    {
                //        Date = item.Key.ToString("dd MMM"),
                //        TotalAmount = item.Value
                //    });
                //}
            }
            catch (Exception ex)
            {
                MessageBox.Show("EC-019: No se pudo obtener el numero de planillas", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

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
