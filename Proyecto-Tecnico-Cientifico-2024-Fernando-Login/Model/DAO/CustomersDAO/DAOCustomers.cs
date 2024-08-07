using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
				adp.Fill(ds, "tbCustomers");
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
		public int UpdateCustomers()
		{

			try
			{
				command.Connection = getConnection();

				string query = "UPDATE tbCustomer SET DUI = @param1, names = @param2, lastNames = @param3, phone= @param4, address= @param5, IdtypeC= @param6 WHERE IdCustomer = @param7 ";

				SqlCommand cmd = new SqlCommand(query, command.Connection);

				cmd.Parameters.AddWithValue("param1", DUI1);
                cmd.Parameters.AddWithValue("param2", Names);
                cmd.Parameters.AddWithValue("param3", LastNames);
                cmd.Parameters.AddWithValue("param4", Phone);
                cmd.Parameters.AddWithValue("param5", Address);
                cmd.Parameters.AddWithValue("param6", IdtypeC1);
                cmd.Parameters.AddWithValue("param7", IdCustomer1);

				int respuesta = cmd.ExecuteNonQuery();

				return respuesta;

            }
			catch (Exception)
			{
				return -1;

				
			}
			finally
			{
				getConnection().Close();
			}
		}
    }
}
