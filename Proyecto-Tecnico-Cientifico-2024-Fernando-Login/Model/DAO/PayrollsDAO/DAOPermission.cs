using PTC2024.Model.DTO.PayrollDTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
                MessageBox.Show("EC-0100: No se puedieron obtener los datos de la tabla tbStatusPermission");
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
                MessageBox.Show($"Excepcion{e}");
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
                MessageBox.Show("EC-009: No se puedieron obtener los datos de la tabla tbStatusPayroll");
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
                MessageBox.Show("EC-009: No se puedieron obtener los datos de la tabla tbStatusPayroll");
                return null;
            }
            finally
            {
                Command.Connection.Close();
            }
        }
    }
}
