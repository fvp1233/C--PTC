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
                MessageBox.Show("EC-083: No se pudo obtener los datos de los tipos de permisos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MessageBox.Show("EC-084: No se pudo obtener los datos de los estados de permisos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
            finally
            {
                Command.Connection.Close();
            }
        }
        public DataSet GetGenderEmployee()
        {
            try
            {
                Command.Connection = getConnection();
                string query = "SELECT * FROM tbGenders";
                SqlCommand cmd = new SqlCommand(query, Command.Connection);
                cmd.ExecuteNonQuery();
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                adp.Fill(ds, "tbGenders");
                return ds;
            }
            catch (SqlException ex)
            {
                MessageBox.Show("EC-085: No se pudo obtener los generos de los empleados", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MessageBox.Show("EC-086: No se pudo obtener los datos de los permisos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
            finally
            {
                Command.Connection.Close();
            }
        }
        public DataSet GetEmployeeName()
        {
            try
            {
                Command.Connection= getConnection();
                string query = "SELECT CONCAT([Nombres],' ',[Apellidos],'/ DUI: ',DUI,'/ Género: ',[Género]) AS 'Nombre Completo' FROM viewEmployees WHERE [Código] = @param1";
                SqlCommand cmd = new SqlCommand(query, Command.Connection);
                cmd.Parameters.AddWithValue("@param1", IdEmployee);
                cmd.ExecuteNonQuery();
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                adp.Fill(ds, "viewEmployees");
                return ds;
            }
            catch (SqlException ex)
            {
                MessageBox.Show("EC-087: No se pudo obtener los datos del empleado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
            finally
            {
                Command.Connection.Close();
            }
        }
        public DataSet GetEmployeeGender()
        {
            try
            {
                Command.Connection = getConnection();
                string query = "SELECT IdGender FROM tbEmployee WHERE IdEmployee = @IdEmployee";
                SqlCommand cmd = new SqlCommand(query, Command.Connection);
                cmd.Parameters.AddWithValue("@IdEmployee", IdEmployee);
                cmd.ExecuteNonQuery();
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                adp.Fill(ds, "tbEmployee");
                return ds;
            }
            catch (SqlException ex)
            {
                MessageBox.Show("EC-088: No se pudo obtener los datos del empleado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
            finally
            {
                Command.Connection.Close();
            }
        }
        public int UpdateStatusEmployee()
        {
            try
            {
                Command.Connection = getConnection();
                string query = "UPDATE tbEmployee SET IdStatus = @param1 WHERE IdEmployee = @param2";
                SqlCommand cmd = new SqlCommand(query, Command.Connection);
                cmd.Parameters.AddWithValue("@param1", EmployeeStatus);
                cmd.Parameters.AddWithValue("@param2", IdEmployee);
                int answer = cmd.ExecuteNonQuery();
                return answer;
            }
            catch (Exception e)
            {
                MessageBox.Show("EC-089: No se pudo obtener los datos del empleado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }
            finally
            {
                getConnection().Close();
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
                MessageBox.Show("EC-090: No se pudo insertar el permiso", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }
            finally
            {
                Command.Connection = getConnection();
            }
        }
    }
}
