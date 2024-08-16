using PTC2024.Model.DTO.ServicesDTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsControlLibrary1;

namespace PTC2024.Model.DAO.ServicesDAO
{
    internal class DAOAddService : DTOAddService
    {
        /*Se declara el comando Sql*/
        readonly SqlCommand command = new SqlCommand();

        /*Metodo para llenar los combobox*/
        public DataSet GetCategories()
        {
            try
            {
                /*Se abre y declara la conexion*/
                command.Connection = getConnection();
                /*Se declara la consulta*/
                string query = "SELECT * FROM tbCategoryS";
                /*Aca declaramos un comando que contiene la consulta y la conexion*/
                SqlCommand cmd = new SqlCommand(query, command.Connection);
                /*Aca se ejecuta la consulta*/
                cmd.ExecuteNonQuery();       
                /* Aca se recolecta lo que devolvio el cmd */        
                SqlDataAdapter adp = new SqlDataAdapter(cmd);

                DataSet ds = new DataSet();

                /*Aca se llena el DataSet ds con los datos devueltos por el cmd*/
                adp.Fill(ds, "tbCategoryS");
                /*Se retorna el DataSet*/
                return ds;
            }
            catch (SqlException ex)
            {
                /*Este mensaje se mostrara en caso que haya ocurrrido un error*/
                MessageBox.Show("EC-003: No se pudieron obtener las categorias de los servicios", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                /*se retornara un valor nulo*/
                return null;
            }
            finally
            {
                /*Por ultimo se cierra la conexion*/
                command.Connection.Close();
            }


        }


        /*Metodo para insertar datos*/
        public int InsertService()
        {
            try
            {
                /*Se declara y abre la conexion*/
                command.Connection = getConnection();
                /*Se declara la consulta, para esta consulta se uso un proceso almacenado*/
                string query2 = "Exec spInsertDataService @NombreS, @DescripcionS, @MontoS, @Categoria";
                /*Se declara un comando que contiene la consulta con la conexion*/
                SqlCommand cmd2 = new SqlCommand(query2, command.Connection);
                /*Ya que esta consulta lleva parametros, aca es donde se llenan dichos parametros*/
                cmd2.Parameters.AddWithValue("@NombreS", Nombre);
                cmd2.Parameters.AddWithValue("@DescripcionS", Descripcion);
                cmd2.Parameters.AddWithValue("@MontoS", Monto);
                cmd2.Parameters.AddWithValue("@Categoria", Categorias);

                /*Se ejecuta la consulta y se guarda en la variable answer*/
                int answer = cmd2.ExecuteNonQuery();
                /*se valida la respuesta para saber que valor retornar*/
                if (answer == 1)
                {
                    return answer;
                }
                else
                {
                    return 0;
                }


            }
            catch (Exception ex)
            {
                /*En caso haya ocurrido un error se mostrara este mensaje*/
                MessageBox.Show(ex.ToString());
                /*y se retornara -1*/
                return -1;
            }
            finally
            {
                /*Por ultimo se cierra la conexion*/
                command.Connection.Close();
            }

        }
    }
}
