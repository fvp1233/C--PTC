﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PTC2024.Controller.Helper;
using PTC2024.Model.DTO;
using PTC2024.Model.DTO.BillsDTO;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace PTC2024.Model.DAO.BillsDAO
{
    internal class DAOBills : DTOBills
    {
        readonly SqlCommand Command = new SqlCommand();

        public DataSet Bills()
        {
            try
            {
                Command.Connection = getConnection();
                string query = "SELECT * FROM viewBill";
                SqlCommand comd = new SqlCommand(query, Command.Connection);
                comd.ExecuteNonQuery();
                SqlDataAdapter adap = new SqlDataAdapter(comd);
                DataSet ds = new DataSet();
                adap.Fill(ds, "viewBill");
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
        public DataSet SearchDataB(string consulta)
        {
            try
            {
                /*Se declara y abre la conexion*/
                Command.Connection = getConnection();
                /*Se declara la consulta*/
                string query = "SELECT * FROM viewBill WHERE [serviceName] LIKE @consulta OR [Customer] LIKE @consulta";

                /*Se declara el comando que contiene la consulta y la conexion*/
                SqlCommand cmd = new SqlCommand(query, Command.Connection);
                /*Aca se le da valor al parametro de la consulta*/
                cmd.Parameters.AddWithValue("@consulta", "%" + consulta + "%");
                /*Se ejecuta la consulta*/
                cmd.ExecuteNonQuery();

                /*Se crea el adaptador que recibira lo que el cmd devolvio*/
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();

                /*Se llena el DataSet*/
                adp.Fill(ds, "viewBill");
                /*Se retorna el DataSet*/
                return ds;
            }
            catch (Exception ex)
            {
                /*En caso haya ocurrido un error se mostrara este mensaje*/
                MessageBox.Show("Error: " + ex.Message);
                /*Y se retornara un valor nulo*/
                return null;
            }
            finally
            {
                /*Por ultimo se cerrara la conexion*/
                Command.Connection.Close();
            }
        }

        public bool VerifyAdminPassword(SecureString inputPassword)
        {
            try
            {
                bool isPasswordValid = false;
                string storedHash = GetStoredPasswordHash(); // Obtener el hash almacenado desde la base de datos

                // Convertir SecureString a texto simple para su encriptación
                string plainTextPassword = ConvertToUnsecureString(inputPassword);

                // Crear una instancia de CommonClasses
                CommonClasses commonClasses = new CommonClasses();

                // Encriptar la contraseña ingresada usando ComputeSha256Hash
                string hashedInputPassword = commonClasses.ComputeSha256Hash(plainTextPassword);

                // Comparar el hash de la contraseña ingresada con el hash almacenado
                isPasswordValid = (hashedInputPassword == storedHash);

                return isPasswordValid;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al validar contraseña: " + ex.Message);
                return false;
            }
        }



        public string ConvertToUnsecureString(SecureString securePassword)
        {
            if (securePassword == null)
                throw new ArgumentNullException("securePassword");

            IntPtr unmanagedString = IntPtr.Zero;
            try
            {
                unmanagedString = Marshal.SecureStringToGlobalAllocUnicode(securePassword);
                return Marshal.PtrToStringUni(unmanagedString);
            }
            finally
            {
                Marshal.ZeroFreeGlobalAllocUnicode(unmanagedString);
            }
        }
        public string GetStoredPasswordHash()
        {
            string storedHash = ""; 
            Command.Connection = getConnection();
                string query = "SELECT password FROM tbUserData WHERE IdBusinessP = 1";
                SqlCommand command = new SqlCommand(query, Command.Connection);
                storedHash = command.ExecuteScalar()?.ToString();
            
            return storedHash;
        }

        public bool OverBill(int idBill)
        {
            try
            {
                Command.Connection = getConnection();
                Command.CommandText = "UPDATE tbBills SET IdStatusBill = (SELECT IdStatusBill FROM tbStatusBill WHERE StatusName = 'Anulado') WHERE IdBill = @IdBill";
                Command.Parameters.Clear();
                Command.Parameters.AddWithValue("@IdBill", idBill);

                Command.Connection.Open();
                int rowsAffected = Command.ExecuteNonQuery();
                return rowsAffected > 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
                return false;
            }
            finally
            {
                Command.Connection.Close();
            }

        }
        public DataSet CheckboxFiltersMethod(string Method)
        {
            try
            {
                //Abrimos conexión con la base
                Command.Connection = getConnection();
                //Creamos el query para la filtración de los checkbox
                string queryCheckboxMethod = "SELECT * FROM viewBill WHERE [Método de Pago] = @MethodP";
                SqlCommand cmdCheckboxMethod = new SqlCommand(queryCheckboxMethod, Command.Connection);
                //Le damos valor a los parámetros de la consulta
                cmdCheckboxMethod.Parameters.AddWithValue("MethodP", Method);
                //Ejecutamos el query
                cmdCheckboxMethod.ExecuteNonQuery();

                //capturamos la respuesta con un adp
                SqlDataAdapter adpCheckBoxStatus = new SqlDataAdapter(cmdCheckboxMethod);
                //Creamos un dataset
                DataSet dsCheckBoxMethod = new DataSet();
                //Llenamos el data set
                adpCheckBoxStatus.Fill(dsCheckBoxMethod, "viewBill");
                //retornamos el dataset
                return dsCheckBoxMethod;
            }
            catch (Exception ex)
            {
                //Si ocurre un error en el try, devolvemos un null
                MessageBox.Show(ex.Message);
                return null;

            }
            finally
            {
                Command.Connection.Close();
            }
        }
        public DataSet CheckboxFiltersStatus(string status)
        {
            try
            {
                //Abrimos conexión con la base
                Command.Connection = getConnection();
                //Creamos el query para la filtración de los checkbox
                string queryCheckboxStatus = "SELECT * FROM viewBill WHERE [Estado] = @StatusBills";
                SqlCommand cmdCheckboxStatus = new SqlCommand(queryCheckboxStatus, Command.Connection);
                //Le damos valor a los parámetros de la consulta
                cmdCheckboxStatus.Parameters.AddWithValue("StatusBills", status);
                //Ejecutamos el query
                cmdCheckboxStatus.ExecuteNonQuery();

                //capturamos la respuesta con un adp
                SqlDataAdapter adpCheckBoxStatus = new SqlDataAdapter(cmdCheckboxStatus);
                //Creamos un dataset
                DataSet dsCheckBoxStatus = new DataSet();
                //Llenamos el data set
                adpCheckBoxStatus.Fill(dsCheckBoxStatus, "viewBill");
                //retornamos el dataset
                return dsCheckBoxStatus;
            }
            catch (Exception ex)
            {
                //Si ocurre un error en el try, devolvemos un null
                MessageBox.Show(ex.Message);
                return null;

            }
            finally
            {
                Command.Connection.Close();
            }
        }
        public DataSet SearchData(string consulta)
        {
            try
            {
                /*Se declara y abre la conexion*/
                Command.Connection = getConnection();
                /*Se declara la consulta*/
                string query = "SELECT * FROM viewBill WHERE [Cliente] LIKE @consulta OR [Servicios] LIKE @consulta";

                /*Se declara el comando que contiene la consulta y la conexion*/
                SqlCommand cmd = new SqlCommand(query, Command.Connection);
                /*Aca se le da valor al parametro de la consulta*/
                cmd.Parameters.AddWithValue("@consulta", "%" + consulta + "%");
                /*Se ejecuta la consulta*/
                cmd.ExecuteNonQuery();

                /*Se crea el adaptador que recibira lo que el cmd devolvio*/
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();

                /*Se llena el DataSet*/
                adp.Fill(ds, "viewBill");
                /*Se retorna el DataSet*/
                return ds;
            }
            catch (Exception ex)
            {
                /*En caso haya ocurrido un error se mostrara este mensaje*/
                MessageBox.Show("Error: " + ex.Message);
                /*Y se retornara un valor nulo*/
                return null;
            }
            finally
            {
                /*Por ultimo se cerrara la conexion*/
                Command.Connection.Close();
            }
        }
    }

}
