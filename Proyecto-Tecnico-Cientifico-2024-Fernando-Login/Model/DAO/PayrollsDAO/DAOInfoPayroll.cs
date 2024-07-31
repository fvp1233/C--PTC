using PTC2024.Model.DTO.PayrollDTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using PTC2024.View.Empleados;
using System.Windows.Input;

namespace PTC2024.Model.DAO.PayrollsDAO
{
    internal class DAOInfoPayroll : DTOInfoPayroll
    {
        readonly SqlCommand comand = new SqlCommand();
    }
}
