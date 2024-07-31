using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PTC2024.Model.DTO;
using PTC2024.Model.DTO.BillsDTO;

namespace PTC2024.Model.DAO.BillsDAO
{
    internal class DAOBills : DTOBills
    {
        readonly SqlCommand Command = new SqlCommand();

        //public DataSet CompleteCombo()
        //{
        //    try
        //    {
        //        Command.Connection = getConnection();
        //        string query = "SELECT * FROM tbStatusBill";
        //        string query = "SELECT * FROM tbMethodP";
        //        SqlCommand cmd
        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
        //}
    }
}