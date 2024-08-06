using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using PTC2024.formularios.login;
using PTC2024.View.Empleados;
using PTC2024.View.Facturacion;
using PTC2024.View.formularios.inicio;
using PTC2024.View.login;
using PTC2024.View.InventarioServicios;
using PTC2024.View.BillsViews;
using PTC2024.Controller.Helper;
using PTC2024.View.Clientes;
using System.Web.UI.WebControls;
using PTC2024.View.Start;

namespace PTC2024
{
    internal static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);


            ControllerInitialView.InitialView();
        }

    }
}
