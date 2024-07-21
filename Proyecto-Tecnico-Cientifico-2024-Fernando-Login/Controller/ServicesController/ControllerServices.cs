using PTC2024.View.InventarioServicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTC2024.Controller.ServicesController
{
    internal class ControllerServices
    {
        FrmServices objServices;

        public ControllerServices(FrmServices view) 
        {
            objServices = view;

            objServices.btnAgregarServicio.Click += new EventHandler(OpenAddService);
            
        }

        public void OpenAddService(object sender, EventArgs e)
        {
            FrmAddService objAddService = new FrmAddService();
            objAddService.Show();
        }
    }
}
