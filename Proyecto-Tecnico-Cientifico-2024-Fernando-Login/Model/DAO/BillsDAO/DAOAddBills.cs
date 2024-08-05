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
using RestSharp;
using System.Runtime.InteropServices.ComTypes;
using PTC2024.Model.DAO.ServicesDAO;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using System.Net;
using System.Xml.Linq;
using System.Security.Cryptography;
using PTC2024.Model.DTO.CustomersDTO;
using PTC2024.Model.DAO.CustomersDAO;

namespace PTC2024.Model.DAO.BillsDAO
{
    internal class DAOAddBills : DTOBills
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
        public DataSet BillsD()
        {
            try
            {
                Command.Connection = getConnection();
                string query3 = "SELECT * FROM viewDetail";
                SqlCommand comd3 = new SqlCommand(query3, Command.Connection);
                //comd3.ExecuteNonQuery();
                SqlDataAdapter adap = new SqlDataAdapter(comd3);
                DataSet ds = new DataSet();
                adap.Fill(ds, "viewDetail");
                return ds;
            }
            catch (Exception)
            {
                return null;
                throw;
            }
            finally
            {
                getConnection().Close();
            }
        }
      
        public int DataB()
        {
            try
            {
                Command.Connection = getConnection();
                string query3 = "INSERT INTO tbBillDataS(IdServices, Price) VALUES (@param1, @param2)";
                SqlCommand comd3 = new SqlCommand(query3, Command.Connection);
                comd3.Parameters.AddWithValue("param1", IdServices1);
                comd3.Parameters.AddWithValue("param2", Price1);
                /*comd3.ExecuteNonQuery();*/
                int An = comd3.ExecuteNonQuery();
                if (An == 1)
                {
                    return An;
                }
                else
                {
                    return 0;
                }


            }
            catch (Exception)
            {
                return -1;
                throw;
            }
            finally
            {
                getConnection().Close();
            }
        }
        public float GetServicePrice(int serviceId)
        {
            try
            {
                Command.Connection = getConnection();
                string query = "SELECT serviceAmount FROM tbServices WHERE IdServices = @IdServices";
                SqlCommand comd = new SqlCommand(query, Command.Connection);
                comd.Parameters.AddWithValue("@IdServices", serviceId);
                object result = comd.ExecuteScalar();

                if (result != null)
                {
                    return float.Parse(result.ToString());
                }
                else
                {
                    throw new Exception("El servicio no fue encontrado.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("EC-011: No se obtuvo el precio del servicio. Error: " + ex.Message);
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
                // Conexión con la base de datos
                Command.Connection = getConnection();
                string queryAddBill = "INSERT INTO tbBills(companyName, NIT, NRC, discount, subtotalPay, totalPay, startDate, finalDate,dateissuance, IdServices, IdStatusBill, IdCustomer, IdEmployee, IdMethodP) " +
                                      "VALUES (@param1, @param2, @param3, @param4, @param5, @param6, @param7, @param8, @param9, @param10, @param11, @param12, @param13, @param14)";

                // Se crea el comando SQL con la conexión y el query
                SqlCommand cmdAddBills = new SqlCommand(queryAddBill, Command.Connection);

                // Se asigna un valor a cada parámetro con los atributos del DTO
                cmdAddBills.Parameters.AddWithValue("@param1", CompanyName);
                cmdAddBills.Parameters.AddWithValue("@param2", NIT1);
                cmdAddBills.Parameters.AddWithValue("@param3", NRC1);
                cmdAddBills.Parameters.AddWithValue("@param4", Discount);
                cmdAddBills.Parameters.AddWithValue("@param5", SubtotalPay);
                cmdAddBills.Parameters.AddWithValue("@param6", TotalPay);
                cmdAddBills.Parameters.AddWithValue("@param7", StartDate);
                cmdAddBills.Parameters.AddWithValue("@param8", FinalDate1);
                cmdAddBills.Parameters.AddWithValue("@param9", Dateissued);
                cmdAddBills.Parameters.AddWithValue("@param10", Services);
                cmdAddBills.Parameters.AddWithValue("@param11", StatusBills);
                cmdAddBills.Parameters.AddWithValue("@param12", Customer);
                cmdAddBills.Parameters.AddWithValue("@param13", Employee);
                cmdAddBills.Parameters.AddWithValue("@param14", MethodP);
                int checks = cmdAddBills.ExecuteNonQuery();
                return checks == 1 ? checks : 0;

            }
            catch (Exception ex)
            {
                MessageBox.Show("EC-10: No se ingresaron los datos. Error: " + ex.Message);
                return -1;
            }
            finally
            {
                Command.Connection.Close();
            }
        }


        /* public int RegisterBills()
     {
         try
         {
             //Conexión con la base de datos
             Command.Connection = getConnection();
             string queryAddBill = "INSERT INTO tbBills(companyName, NIT, NRC, discount, subtotalPay, totalPay, startDate, FinalDate, IdServices, IdStatusBill, IdCustomer, IdEmployee, IdmethodP, FiscalPeriod, IdfiscalPeriod) VALUES (@param1, @param2, @param3,@param4,@param5, @param6, @param7, @param8, @param9,@param10, @param11, @param12,@param13,@param14)";
             //Se crea el comando SQL con la conexión y el query
             SqlCommand cmdAddBills = new SqlCommand(@queryAddBill, Command.Connection);
             //Se asigna un valor a cada parámetro con los atributos del DTO
             cmdAddBills.Parameters.AddWithValue("param1", CompanyName);
             cmdAddBills.Parameters.AddWithValue("param2", NIT1);
             cmdAddBills.Parameters.AddWithValue("param3", NRC1);
             cmdAddBills.Parameters.AddWithValue("param4", Discount);
             cmdAddBills.Parameters.AddWithValue("param5", SubtotalPay);
             cmdAddBills.Parameters.AddWithValue("param6", TotalPay);
             cmdAddBills.Parameters.AddWithValue("param7", StartDate);
             cmdAddBills.Parameters.AddWithValue("param8", FinalDate1);
             cmdAddBills.Parameters.AddWithValue("param9", Services);
             cmdAddBills.Parameters.AddWithValue("param10", StatusBills);
             cmdAddBills.Parameters.AddWithValue("param11", Customer);
             cmdAddBills.Parameters.AddWithValue("param12", Employee);
             cmdAddBills.Parameters.AddWithValue("param13", MethodP);
             cmdAddBills.Parameters.AddWithValue("param14", FiscalPeriod);
             int checks = cmdAddBills.ExecuteNonQuery();
             if (checks == 1)
             {
                 return checks;
             }
             else
             {
                 return 0;
             }
         }
         catch (Exception ex)
         {
             MessageBox.Show("EC-10: No se ingresaron los datos");

             return -1;
             //se retorna -1 en caso de que haya ocurrido un error en el try
         }
         finally
         {
             Command.Connection.Close();
         }

     }  */
    }
}