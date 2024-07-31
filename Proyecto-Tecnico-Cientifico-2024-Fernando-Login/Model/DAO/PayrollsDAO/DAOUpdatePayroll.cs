using PTC2024.Model.DTO.PayrollDTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTC2024.Model.DAO.PayrollsDAO
{
    internal class DAOUpdatePayroll:DTOUpdatePayroll
    {
		readonly SqlCommand Command = new SqlCommand();
		//public int UpdatePayroll()
		//{
		//	try
		//	{
		//		//Creamos la conexion para garantizar que este conectado a la base
		//		Command.Connection = getConnection();
		//		//Creamos el query
		//		string query = "";

		//	}
		//	catch (Exception)
		//	{

		//		throw;
		//	}
		//}
	}
}
