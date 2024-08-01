using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PTC2024.Model.DTO;
using PTC2024.Model.DTO.BillsDTO;
using PTC2024.Model;
using System.Windows.Forms;
using System.Security.Cryptography.X509Certificates;
using System.Web.UI.WebControls;

namespace PTC2024.Model.DAO.BillsDAO
{
    internal class DAOAddBills:DTOBills
    {
        readonly SqlCommand Command = new SqlCommand();
        public DataSet Methodp()
        {
			try
			{
                Command.Connection = getConnection();
                string query = "SELECT*FROM tbMethodP";
                SqlCommand comd = new SqlCommand(query, Command.Connection);
                comd.ExecuteNonQuery();
                SqlDataAdapter adap = new SqlDataAdapter(comd);
                DataSet ds = new DataSet();
                adap.Fill(ds, "tbMethodP");
                return ds;

            }
            catch (Exception)
			{
                MessageBox.Show("EC-007:No se obtuvieron los datos de Método de Pago");
				throw;
			}
            finally
            {
                getConnection().Close();
            }
        }
        public DataSet statusBill()
        {
            try
            {
                Command.Connection = getConnection();
                string query = "SELECT*FROM tbStatusBill";
                SqlCommand comd = new SqlCommand(query, Command.Connection);
                comd.ExecuteNonQuery();
                SqlDataAdapter adap = new SqlDataAdapter(comd);
                DataSet ds = new DataSet();
                adap.Fill(ds, "tbStatusBill");
                return ds;

            }
            catch (Exception)
            {
                MessageBox.Show("EC-008:No se obtuvieron los datos del estado de factura");
                throw;
            }
            finally
            {
                getConnection().Close();
            }
        }
        public DataSet DataServices()
        {
            try
            {
                Command.Connection = getConnection();
                string query = "SELECT*FROM tbServices";
                SqlCommand comd = new SqlCommand(query, Command.Connection);
                comd.ExecuteNonQuery();
                SqlDataAdapter adap = new SqlDataAdapter(comd);
                DataSet ds = new DataSet();
                adap.Fill(ds, "tbServices");
                return ds;

            }
            catch (Exception
            )
            {
                MessageBox.Show("EC-009:No se obtuvieron los datos de los servicios");
                throw;
            }
            finally
            {
                getConnection().Close();
            }
        }
        public int RegisterBills()
        {
            try
            {
                Command.Connection = getConnection();
                string query2 = "INSERT INTO tbfiscalPeriod(IdfiscalPeriod, dateissuence) VALUES (@IdfiscalPeriod, @dateissuence)";
                SqlCommand comd2 = new SqlCommand(query2, Command.Connection);
                comd2.Parameters.AddWithValue("IdfiscalPeriod",FiscalPeriod);
                int checks = comd2.ExecuteNonQuery();
                if (checks == 1)
                Command.Connection= getConnection();
                string query = "INSERT INTO tbBills(companyName,NIT,NRC, discount, subtotalPay, totalPay, startDate, FinalDate,services, statusBill, customer, employee, methodP, fiscalPeriod) VALUES (@param1, @param2, @param3,@param4,@param5, @param6, @param7, @param8, @param9,@param10, @param11, @param12,@param13,@param14,@param15)";
                SqlCommand comd = new SqlCommand( query, Command.Connection);
                comd.Parameters.AddWithValue("param1", CompanyName);
                comd.Parameters.AddWithValue("param2", NIT1);
                comd.Parameters.AddWithValue("param3", NRC1);
                comd.Parameters.AddWithValue("param5", Discount);
                comd.Parameters.AddWithValue("param6", SubtotalPay);
                comd.Parameters.AddWithValue("param7", TotalPay);
                comd.Parameters.AddWithValue("param8", StartDate);
                comd.Parameters.AddWithValue("param9", FinalDate1);
                comd.Parameters.AddWithValue("param10", Services);
                comd.Parameters.AddWithValue("param11", StatusBills);
                comd.Parameters.AddWithValue("param12", Customer);
                comd.Parameters.AddWithValue("param13", Employee);
                comd.Parameters.AddWithValue("param14", MethodP);
                comd.Parameters.AddWithValue("param15", FiscalPeriod);
                checks = comd.ExecuteNonQuery();
                return checks;
            }
            catch (Exception)
            {
                MessageBox.Show("EC-10: No se ingresaron los datos");
                return -1;

                throw;
            }
            finally
            {
                Command.Connection.Close();
            }
        }
        

    }
}
