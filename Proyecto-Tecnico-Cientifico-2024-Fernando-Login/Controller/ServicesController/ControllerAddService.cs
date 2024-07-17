using PTC2024.Model.DAO.ServicesDAO;
using PTC2024.View.InventarioServicios;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTC2024.Controller.ServicesController
{
    internal class ControllerAddService
    {
        FrmAddService objAddService;

        public ControllerAddService(FrmAddService view) { 
            objAddService = view;
            objAddService.Load += new EventHandler(cargarcombos);
            objAddService.BtnCancelar.Click += new EventHandler(cerrarform);
        }

        public void cargarcombos(object sender, EventArgs e)
        {
            DAOAddService daoAddService = new DAOAddService();

            DataSet dsAddService = daoAddService.ObtenerCategoriasServicios();
            objAddService.comboTipoEmpleado.DataSource = dsAddService.Tables["tbCategoryS"];
            objAddService.comboTipoEmpleado.DisplayMember = "categoryName";
            objAddService.comboTipoEmpleado.ValueMember = "Id_Category";
        }

        public void cerrarform(object sender, EventArgs e)
        {
            objAddService.Close();
        }
    }
}
