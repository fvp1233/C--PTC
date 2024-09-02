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
using System.Collections;
using System.Windows.Input;

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


        /*
        public bool VerificarClienteExistente(string customer)
        {
            try
            {
                Command.Connection = getConnection();
                string query = "SELECT COUNT(*) FROM tbCustomer WHERE Names = @customer";
                SqlCommand cmd = new SqlCommand(query, Command.Connection);
                cmd.Parameters.AddWithValue("@customer", customer);
                int count = (int)cmd.ExecuteScalar();

                return count > 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("EC-012: Error al verificar la existencia del cliente. " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            finally
            {
                getConnection().Close();
            }
        }

        public bool CustomerIdentificator(string customer)
        {
            try
            {
                Command.Connection = getConnection();
                string query = "SELECT COUNT(*) FROM tbCustomer WHERE LastNames = @customer";
                SqlCommand cmd = new SqlCommand(query, Command.Connection);
                cmd.Parameters.AddWithValue("@customer", customer);
                int count = (int)cmd.ExecuteScalar();

                return count > 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("EC-012: Error al verificar la existencia del cliente. " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            finally
            {
                getConnection().Close();
            }
        }
        public bool CustomerD(string customer)
        {
            try
            {
                Command.Connection = getConnection();
                string query = "SELECT COUNT(*) FROM tbCustomer WHERE DUI = @DUI1";
                SqlCommand cmd = new SqlCommand(query, Command.Connection);
                cmd.Parameters.AddWithValue("@DUI1", customer);
                int count = (int)cmd.ExecuteScalar();

                return count > 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("EC-012: Error al verificar la existencia del cliente. " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            finally
            {
                getConnection().Close();
            }
        }
        /*
        public DataSet GetCustomer()
        {
            try
            {
                Command.Connection = getConnection();
                string queryCustomer = "SELECT * FROM tbCustomer";
                SqlCommand cmd = new SqlCommand(queryCustomer, Command.Connection);
                cmd.ExecuteNonQuery();
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                adp.Fill(ds, "tbCustomer");
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
        */
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
        /// <summary>
        /// Busca la coincidencia de los nombres a ingresar
        /// </summary>
        /// <param name="CustomerName"></param>
        /// <returns></returns>

        public List<string> GetCustomerNames(string CustomerName)
        {
            List<string> customerNames = new List<string>();

            using (SqlConnection connection = getConnection())
            {
                // Abre la conexión solo si está cerrada
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }

                string query = "SELECT DISTINCT TRIM(names + ' ' + lastNames) AS FullName " +
                               "FROM tbCustomer " +
                               "WHERE TRIM(names + ' ' + lastNames) LIKE '%' + @CustomerName + '%'";

                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@CustomerName", CustomerName);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            customerNames.Add(reader["FullName"].ToString());
                        }
                    }
                }
            }

            return customerNames;
        }

        /// <summary>
        /// Una vez encontrado el cliente este se filtran todos los datos que contiene
        /// </summary>
        /// <param name="CustomerName"></param>
        /// <returns></returns>
        public Dictionary<string, string> GetCustomerDetails(string CustomerName)
        {
            Dictionary<string, string> clienteData = new Dictionary<string, string>();

            try
            {
                using (SqlConnection connection = getConnection())
                {
                    if (connection.State == ConnectionState.Closed)
                    {
                        connection.Open();
                    }

                    string query = "SELECT IdCustomer, DUI, phone, email " +
                                   "FROM tbCustomer " +
                                   "WHERE TRIM(names + ' ' + lastNames) = TRIM(@CustomerName)";

                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@CustomerName", CustomerName);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                clienteData["IdCustomer"] = reader["IdCustomer"].ToString();
                                clienteData["DUI"] = reader["DUI"].ToString();
                                clienteData["phone"] = reader["phone"].ToString();
                                clienteData["email"] = reader["email"].ToString();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Log del error o muestra el mensaje
                MessageBox.Show($"Error al obtener detalles del cliente: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return clienteData;
        }

        public List<string> GetEmployeesNames(string EmployeeName)
        {
            List<string> EmployeeNames = new List<string>();

            using (SqlConnection connection = getConnection())
            {
                // Abre la conexión solo si está cerrada
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }

                string query = "SELECT DISTINCT TRIM(names + ' ' + lastName) AS FullName " +
                               "FROM tbEmployee " +
                               "WHERE TRIM(names + ' ' + lastName) LIKE '%' + @EmployeeName + '%'";

                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@EmployeeName", EmployeeName);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            EmployeeNames.Add(reader["FullName"].ToString());
                        }
                    }
                }
            }

            return EmployeeNames;
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
                SqlCommand cmd = new SqlCommand("spNewBill", Command.Connection);
                cmd.CommandType = CommandType.StoredProcedure;

                // Asignar parámetros
                cmd.Parameters.AddWithValue("@CompanyName", CompanyName);
                cmd.Parameters.AddWithValue("@NIT", NIT1);
                cmd.Parameters.AddWithValue("@NRC", NRC1);
                cmd.Parameters.AddWithValue("@CustomerDui", CustomerDui1);
                cmd.Parameters.AddWithValue("@CustomerPhone", CustomerPhone1);
                cmd.Parameters.AddWithValue("@CustomerEmail", CustomerEmail1);
                cmd.Parameters.AddWithValue("@Discount", Discount);
                cmd.Parameters.AddWithValue("@SubtotalPay", SubtotalPay);
                cmd.Parameters.AddWithValue("@TotalPay", TotalPay);
                cmd.Parameters.AddWithValue("@StartDate", StartDate);
                cmd.Parameters.AddWithValue("@FinalDate", FinalDate1);
                cmd.Parameters.AddWithValue("@DateIssuance", Dateissued);
                cmd.Parameters.AddWithValue("@IdServices", Services);
                cmd.Parameters.AddWithValue("@IdStatusBill", StatusBills);
                cmd.Parameters.AddWithValue("@CustomerName", Customer);
                cmd.Parameters.AddWithValue("@EmployeeName", Employee);
                cmd.Parameters.AddWithValue("@IdMethodP", MethodP);

                int checks = cmd.ExecuteNonQuery();
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
        public int GetCustomerIdByName(string customerName)
        {
            int customerId = -1;

            try
            {
                Command.Connection = getConnection();
                string query = "SELECT IdCustomer FROM tbCustomer WHERE names + ' ' + lastNames = @CustomerName";
                using (SqlCommand cmd = new SqlCommand(query, Command.Connection))
                {
                    cmd.Parameters.AddWithValue("@CustomerName", customerName);

                    try
                    {
                        Command.Connection.Open();
                        object result = cmd.ExecuteScalar();
                        if (result != null)
                        {
                            customerId = Convert.ToInt32(result);
                        }
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Cliente registrado");
                    }
                    finally
                    {
                        Command.Connection.Close(); // Cerrar la conexión una vez
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex.Message);
            }

            return customerId; // Devolver el valor de customerId
        }

        public int GetEmployeeIdByName(string EmployeeName)
        {
            int EmployeeId = -1;

            try
            {
                Command.Connection = getConnection();
                string query = "SELECT IdEmployee FROM tbEmployee WHERE names + ' ' + lastName = @EmployeeName";
                using (SqlCommand cmd = new SqlCommand(query, Command.Connection))
                {
                    cmd.Parameters.AddWithValue("@EmployeeName", EmployeeName);

                    try
                    {
                        Command.Connection.Open();
                        object result = cmd.ExecuteScalar();
                        if (result != null)
                        {
                            EmployeeId = Convert.ToInt32(result);
                        }
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Empleado registrado");
                    }
                    finally
                    {
                        Command.Connection.Close(); // Cerrar la conexión una vez
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex.Message);
            }

            return EmployeeId; // Devolver el valor de EmployeeId
        }


    }
}

