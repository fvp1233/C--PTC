using PTC2024.Model.DTO.PayrollDTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PTC2024.Model.DAO.PayrollsDAO
{
    internal class DAOUpdatePermission : DTOPermission
    {
        readonly SqlCommand Command = new SqlCommand();
        public int UpdatePermission()
        {
            try
            {
                Command.Connection = getConnection();
                string query = "UPDATE tbPermissions SET startDay = @param1, finishDay = @param2, context = @param3, IdEmployee = @param4, IdTypePermission = @param5, IdStatusPermission = @param6 WHERE IdPermission = @param7";
                SqlCommand cmd = new SqlCommand(query, Command.Connection);
                cmd.Parameters.AddWithValue("@param1", Start);
                cmd.Parameters.AddWithValue("@param2", End);
                cmd.Parameters.AddWithValue("@param3", Context);
                cmd.Parameters.AddWithValue("@param4", IdEmployee);
                cmd.Parameters.AddWithValue("@param5", IdTypePermission);
                cmd.Parameters.AddWithValue("@param6", IdStatusPermission);
                cmd.Parameters.AddWithValue("@param7", IdPermission);
                int answer = cmd.ExecuteNonQuery();
                return answer;

            }
            catch (Exception e)
            {
                MessageBox.Show($"Excepcion{e}");
                return -1;
            }
            finally
            {
                getConnection().Close();
            }
        }
        public DataSet GetTypePermission()
        {
            try
            {
                Command.Connection = getConnection();
                string query = "SELECT * FROM tbTypePermission";
                SqlCommand cmd = new SqlCommand(query, Command.Connection);
                cmd.ExecuteNonQuery();
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                adp.Fill(ds, "tbTypePermission");
                return ds;
            }
            catch (SqlException ex)
            {
                MessageBox.Show("EC-009: No se puedieron obtener los datos de la tabla tbStatusPayroll");
                return null;
            }
            finally
            {
                Command.Connection.Close();
            }
        }
        public DataSet GetStatusPermission()
        {
            try
            {
                Command.Connection = getConnection();
                string query = "SELECT * FROM tbStatusPermission";
                SqlCommand cmd = new SqlCommand(query, Command.Connection);
                cmd.ExecuteNonQuery();
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                adp.Fill(ds, "tbStatusPermission");
                return ds;
            }
            catch (SqlException ex)
            {
                MessageBox.Show("EC-009: No se puedieron obtener los datos de la tabla tbStatusPermission");
                return null;
            }
            finally
            {
                Command.Connection.Close();
            }
        }
    }
}
