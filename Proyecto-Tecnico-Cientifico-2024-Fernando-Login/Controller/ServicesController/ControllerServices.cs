using PTC2024.Model.DAO.ServicesDAO;
using PTC2024.View.InventarioServicios;
using PTC2024.View.Service_inventory;
using System;
using System.Collections.Generic;
using System.Data;
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

            objServices.Load += new EventHandler(ChargeData);
            objServices.btnAgregarServicio.Click += new EventHandler(OpenAddService);
            objServices.cmsUpdateService.Click += new EventHandler(OpenUpdateService);

        }

        public void ChargeData(object sender, EventArgs e)
        {
            ChargeDgv();
        }

        public void ChargeDgv()
        {
            DAOServices dAOServices = new DAOServices();
            DataSet Result = dAOServices.GetDataTable();
            objServices.DgvServicios.DataSource = Result.Tables["tbServices"];
        }

        public void OpenUpdateService(object sender, EventArgs e)
        {
            FrmUpdateService objUpdateService = new FrmUpdateService();
            objUpdateService.Show();
        }

        public void OpenAddService(object sender, EventArgs e)
        {
            FrmAddService objAddService = new FrmAddService();
            objAddService.Show();
        }

    }
}
