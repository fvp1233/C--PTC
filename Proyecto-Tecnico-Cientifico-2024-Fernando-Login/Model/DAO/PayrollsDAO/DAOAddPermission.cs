using PTC2024.Model.DTO.PayrollDTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PTC2024.Model.DAO.PayrollsDAO
{
    internal class DAOAddPermission : DTOAddPermission
    {
		readonly SqlCommand Command = new SqlCommand();
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
        public DataSet GetPermissions()
        {
            try
            {
                Command.Connection = getConnection();
                string query = "SELECT * FROM viewPermissions";
                SqlCommand cmd = new SqlCommand(query, Command.Connection);
                cmd.ExecuteNonQuery();
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                adp.Fill(ds, "viewPermissions");
                return ds;
            }
            catch (SqlException ex)
            {
                MessageBox.Show("EC-0100: No se puedieron obtener los datos de la tabla tbStatusPermission");
                return null;
            }
            finally
            {
                Command.Connection.Close();
            }
        }
        public int InsertPermission()
        {
            try
            {
                Command.Connection = getConnection();
                string query = "INSERT INTO tbPermissions (startDay, finishDay, context, IdEmployee, IdTypePermission, IdStatusPermission) VALUES (@startDay, @finishDay, @context, @IdEmployee, @IdTypePermission, @IdStatusPermission)";
                SqlCommand cmd = new SqlCommand(query, Command.Connection);
                cmd.Parameters.AddWithValue("startDay", Start);
                cmd.Parameters.AddWithValue("finishDay", End);
                cmd.Parameters.AddWithValue("context", Context);
                cmd.Parameters.AddWithValue("IdEmployee", IdEmployee);
                cmd.Parameters.AddWithValue("IdTypePermission", IdTypePermission);
                cmd.Parameters.AddWithValue("IdStatusPermission", IdStatusPermission);
                int answer = cmd.ExecuteNonQuery();
                return answer;
            }
            catch (Exception)
            {
                return -1;
            }
            finally
            {
                Command.Connection = getConnection();
            }
        }
    }
}
