using PTC2024.Model.DTO.PayrollDTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;

namespace PTC2024.Model.DAO.PayrollsDAO
{
    internal class DAOPermission : DTOPermission
    {
        readonly SqlCommand Command = new SqlCommand();
        public DataSet GetPermissions()
        {
            try
            {
                Command.Connection = getConnection();
                string query = "SELECT * FROM viewPermissions WHERE [Estado de permiso] = 'En proceso' OR  [Estado de permiso] = 'Completado'";
                SqlCommand cmd = new SqlCommand(query, Command.Connection);
                cmd.ExecuteNonQuery();
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                adp.Fill(ds, "viewPermissions");
                return ds;
            }
            catch (SqlException ex)
            {
                MessageBox.Show("EC-077: No se pudieron obtener los permisos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
            finally
            {
                Command.Connection.Close();
            }
        }
        public int UpdateDsEPermission()
        {
            try
            {
                Command.Connection = getConnection();
                string query = "UPDATE tbPermissions SET IdStatusPermission = @param1 WHERE IdEmployee = @param2";
                SqlCommand cmd = new SqlCommand(query, Command.Connection);
                cmd.Parameters.AddWithValue("@param1", IdStatusPermission);
                cmd.Parameters.AddWithValue("@param2", IdEmployee);
                int answer = cmd.ExecuteNonQuery();
                return answer;
            }
            catch (Exception e)
            {
                MessageBox.Show("EC-078: No se pudo actualizar el estado del permiso", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }
            finally
            {
                getConnection().Close();
            }
        }
        public int DeletePermission()
        {
            try
            {
                Command.Connection = getConnection();
                string query = "DELETE tbPermissions WHERE IdPermission = @param1";
                SqlCommand cmd = new SqlCommand(query, Command.Connection);
                cmd.Parameters.AddWithValue("param1", IdPermission);
                int respuesta = cmd.ExecuteNonQuery();
                return respuesta;
            }
            catch (Exception)
            {
                MessageBox.Show("EC-079: No se pudo eliminar el permiso", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return -1;
            }
            finally
            {
                getConnection().Close();
            }

        }
        public DataSet GetPermissionsDisable()
        {
            try
            {
                Command.Connection = getConnection();
                string query = "SELECT * FROM tbPermissions";
                SqlCommand cmd = new SqlCommand(query, Command.Connection);
                cmd.ExecuteNonQuery();
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                adp.Fill(ds, "tbPermissions");
                return ds;
            }
            catch (SqlException ex)
            {
                MessageBox.Show("EC-080: No se pudo obtener los datos de los permisos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
            finally
            {
                Command.Connection.Close();
            }
        }
        public DataSet GetEmployee()
        {
            try
            {
                Command.Connection = getConnection();
                string query = "SELECT * FROM tbEmployee";
                SqlCommand cmd = new SqlCommand(query, Command.Connection);
                cmd.ExecuteNonQuery();
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                adp.Fill(ds, "tbEmployee");
                return ds;
            }
            catch (SqlException ex)
            {
                MessageBox.Show("EC-081: No se pudo obtener los datos de los empleados", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
            finally
            {
                Command.Connection.Close();
            }
        }
        public DataSet SearchPayroll(string valor)
        {
            try
            {
                Command.Connection = getConnection();
                string query = $"SELECT * FROM viewPermissions WHERE [Id Empleado] LIKE '%{valor}%' OR [Tipo de permiso] LIKE '%{valor}%' OR [Estado de permiso] LIKE '%{valor}%'";
                SqlCommand cmd = new SqlCommand(query, Command.Connection);
                cmd.ExecuteNonQuery();
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                adp.Fill(ds, "viewPermissions");
                return ds;
            }
            catch (Exception)
            {
                MessageBox.Show("EC-082: No se pudo obtener los datos de los permisos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return null;
            }
            finally
            {
                getConnection().Close();
            }
        }
    }
}
