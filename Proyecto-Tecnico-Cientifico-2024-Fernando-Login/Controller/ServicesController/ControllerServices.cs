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
            objServices.cmsDeleteService.Click += new EventHandler(DeleteService);

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
            objServices.DgvServices.DataSource = Result.Tables["tbServices"];
        }


        public void OpenAddService(object sender, EventArgs e)
        {
            FrmAddService objAddService = new FrmAddService();
            objAddService.Show();
            ChargeDgv();
        }


        public void OpenUpdateService(object sender, EventArgs e)
        {
            int pos = objServices.DgvServices.CurrentRow.Index;

            int id = (int.Parse(objServices.DgvServices[0, pos].Value.ToString()));
            string nombre = objServices.DgvServices[1, pos].Value.ToString();
            string descripcion = objServices.DgvServices[2, pos].Value.ToString();
            double monto = double.Parse(objServices.DgvServices[3, pos].Value.ToString());
            string categoria = objServices.DgvServices[4, pos].Value.ToString();
            FrmUpdateService openForm = new FrmUpdateService( id, nombre, descripcion, monto, categoria);
            openForm.Show();

            ChargeDgv();

        }


        public void DeleteService(object sender, EventArgs e)
        {

        }





    }
}
