using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PTC2024.Model.DTO.CustomersDTO;

namespace PTC2024.Model.DAO.CustomersDAO
{
 class DAOCustomers:DTOCustomers
    {
        readonly SqlCommand command = new SqlCommand(); 

        public DataSet FillCustomers(string tipoPersona)
        {

			try
			{
				command.Connection = getConnection();
				string query = "";
				if (tipoPersona == "N") {
                     query = "SELECT * FROM viewCustomers WHERE [Tipo] ='Natural'";

                }
				//Fijarse en acentos 
				if (tipoPersona == "J")
				{
                     query = "SELECT * FROM viewCustomers WHERE [Tipo] = 'JurÍdico'";
					

                }
				if (tipoPersona == "T") {

                     query = "SELECT * FROM viewCustomers";

                }

                

                SqlCommand cmd = new SqlCommand(query, command.Connection);
				cmd.ExecuteNonQuery();
					
				SqlDataAdapter adp = new SqlDataAdapter(cmd);

				DataSet ds = new DataSet();	
				//tbCustomers es un alias para llamar viewCustomers, se puede llamar de cualquier manera
				adp.Fill(ds, "viewCustomers");
				return ds;
            }
			catch (Exception)
			{
				return null;
				
			}
			finally { 
				command.Connection.Close();
			}
        }

        public int DeleteCustomers()
        {
            try
            {
                /*Se declara y abre la conexion*/
                command.Connection = getConnection();
                /*Se declara la consulta*/
                string query = "DELETE tbCustomer WHERE IdCustomer = @param1";

                /*Se declara el comando que contiene la consulta con la conexion*/
                SqlCommand cmd = new SqlCommand(query, command.Connection);

                /*Se le da valor al parametro @IdCustomer*/
                cmd.Parameters.AddWithValue("@param1", IdCustomer1);

                /*Se ejecuta la consulta que se guardara en la variable respuesta*/
                int respuesta = cmd.ExecuteNonQuery();

                return respuesta;

            }
            catch (Exception)
            {
                /*En caso haya un error se retorna -1*/
                return -1;
            }
            finally
            {
                /*Por ultimo se cierra la conexion*/
                command.Connection.Close();
            }
        }

        public DataSet SearchData(string consulta)
        {
            try
            {
                /*Se declara y abre la conexion*/
                command.Connection = getConnection();
                /*Se declara la consulta*/
                string query = "SELECT * FROM viewCustomers WHERE [Nombre] LIKE @consulta OR [Nombre] LIKE @consulta";

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
                adp.Fill(ds, "viewCustomers");
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
                command.Connection.Close();
            }
        }

    }
}
