using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PTC2024.Model.DTO.ServicesDTO;
using System.Windows.Forms;

namespace PTC2024.Model.DAO.ServicesDAO
{
    internal class DAOServices : DTOServices
    {
        /*Se declara el comando Sql*/
        readonly SqlCommand command = new SqlCommand();

        /*Se declara metodo que retornara los valores del apartado de servicios para llenar el DataGridView*/
        public DataSet GetDataTable()
        {
            try
            {
                /*Se declara y abre la conexion*/
                command.Connection = getConnection();
                /*Se declara la consulta*/
                string query = "SELECT * FROM viewServices";

                /*Se declara comando que contiene la consulta y conexion*/
                SqlCommand cmd = new SqlCommand(query, command.Connection);

                /*Aca se ejecuta la consulta*/
                cmd.ExecuteNonQuery();
                /*Aca se crea un adaptador que guarde lo que el cmd retorno*/
                SqlDataAdapter adp = new SqlDataAdapter(cmd);

                DataSet ds = new DataSet();

                /*Se llena el DataSet*/
                adp.Fill(ds, "viewServices");
                /*Se retorna el DataSet*/
                return ds;

            }
            catch (Exception)
            {
                MessageBox.Show("EC-094: No se pudieron obtener los datos de los servicios", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                /*Si ocurrio un error se retornara un valor nulo*/
                return null;
            }
            finally
            {
                /*Por ultimo se cierra la conexion*/
                command.Connection.Close();
            }
        }

        /*Metodo que borrara los servicios*/
        public int DeleteService()
        {
            try
            {
                /*Se declara y abre la conexion*/
                command.Connection = getConnection();
                /*Se declara la consulta*/
                string query = "Exec spDeleteService @Id";

                /*Se declara el comando que contiene la consulta con la conexion*/
                SqlCommand cmd = new SqlCommand(query, command.Connection);

                /*Se le da valor al parametro @Id*/
                cmd.Parameters.AddWithValue("@Id", IdService1);

                /*Se ejecuta la consulta que se guardara en la variable respuesta*/
                int respuesta = cmd.ExecuteNonQuery();

                /*Se retorna la respuesta*/
                return respuesta;

            }
            catch (Exception)
            {
                MessageBox.Show("EC-095: No se pudo eliminar los datos del servicio", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                /*En caso haya un error se retorna -1*/
                return -1;
            }
            finally
            {
                /*Por ultimo se cierra la conexion*/
                command.Connection.Close();
            }
        }

        /*Este metodo es para buscar sevicios por medio de un textbox*/
        public DataSet SearchData(string consulta)
        {
            try
            {
                /*Se declara y abre la conexion*/
                command.Connection = getConnection();
                /*Se declara la consulta*/
                string query = "SELECT * FROM viewServices WHERE [Nombre servicio] LIKE @consulta OR [Descripción] LIKE @consulta";

                /*Se declara el comando que contiene la consulta y la conexion*/
                SqlCommand cmd = new SqlCommand(query, command.Connection);
                /*Aca se le da valor al parametro de la consulta*/
                cmd.Parameters.AddWithValue("@consulta", "%" + consulta + "%");
                /*Se ejecuta la consulta*/
                cmd.ExecuteNonQuery();

                /*Se crea el adaptador que recibira lo que el cmd devolvio*/
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();

                /*Se llena el DataSet*/
                adp.Fill(ds, "viewServices");
                /*Se retorna el DataSet*/
                return ds;
            }
            catch (Exception ex)
            {
                /*En caso haya ocurrido un error se mostrara este mensaje*/
                MessageBox.Show("EC-096: No se pudo obtener los datos del servicio", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                /*Y se retornara un valor nulo*/
                return null;
            }
            finally 
            {
                /*Por ultimo se cerrara la conexion*/
                command.Connection.Close();
            }
        }

        /*Este metodo es para filtrar los servicios por medio de checkbox*/
        /*El parametro en este caso es la categoria por la cual el usuario quiere filtrar*/
        public DataSet SearchDataCb(string categoria)
        {
            try
            {
                /*Se declara y abre la conexion*/
                command.Connection = getConnection();
                /*Se declara la consulta*/
                string query = "SELECT * FROM viewServices Where [Categoría] = @categoria";
                /*Se delcara el comando con la consulta y la conexion*/
                SqlCommand cmd = new SqlCommand(query, command.Connection);
                /*Se le da valor al parametro de la consulta*/
                cmd.Parameters.AddWithValue("@categoria", categoria);
                /*Se ejecuta la consulta*/
                cmd.ExecuteNonQuery();

                /*Se captura la respuesta con el adp*/
                SqlDataAdapter adp = new SqlDataAdapter(cmd);

                DataSet ds = new DataSet();

                /*Se llena el DataSet*/
                adp.Fill(ds, "viewServices");
                /*Se retorna el DataSet*/
                return ds;
            }
            catch (Exception)
            {
                MessageBox.Show("EC-097: No se pudo obtener los datos del servicio", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
            finally
            {
                /*Se cierra la conexion*/
                command.Connection.Close(); 
            }
        }
    }

}


