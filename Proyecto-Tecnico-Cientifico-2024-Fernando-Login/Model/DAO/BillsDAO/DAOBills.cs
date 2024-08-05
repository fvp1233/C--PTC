using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PTC2024.Model.DTO;
using PTC2024.Model.DTO.BillsDTO;

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
                string query = "SELECT * FROM viewBills";
                SqlCommand comd = new SqlCommand(query, Command.Connection);
                //comd.ExecuteNonQuery();
                SqlDataAdapter adap = new SqlDataAdapter(comd);
                DataSet ds = new DataSet();
                adap.Fill(ds, "viewBills");
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
                string query = "SELECT * FROM viewBills WHERE [IdBill] LIKE @consulta OR [serviceName] LIKE @consulta";

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
                adp.Fill(ds, "viewBills");
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